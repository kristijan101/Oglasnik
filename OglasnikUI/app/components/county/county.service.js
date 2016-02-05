(function () {
	angular.module('app').factory('countyService', ['$q', '$http', 'CacheFactory','API_URL', countyService]);

	function countyService($q, $http, CacheFactory, API_URL) {
		'use strict';

		var cache = CacheFactory.get('countyCache') 
				 	|| CacheFactory('countyCache', {
							maxAge: 5 * 60 * 1000,
							deleteOnExpire: 'aggressive'
						});
		var countyUrl = API_URL + '/county';

		return {
			add: function(county) {
				return $http.post(countyUrl, county);
			},			
			get: function (options) {
				return $http.get(countyUrl, 
					{
						params: 
						{
							q : options.query || "", 
							page : options.page || 1, 
							size : options.size || 20, 
							sort : options.orderBy || "name", 
							asc : options.orderDirection === 'desc' ? false : true
						}
					}
					).then(
						function (response) {
							var counties = response.data;

							for(var i in counties){
								var county = counties[i];

								if(!cache.get(county.Id)) cache.put(county.Id, county);
							}
							return counties;
						}
					);
			},
			getById: function(id){
				var county = cache.get(id);

				if(county){
					return $q.when(county);
				}
				else 
				{
					return $http.get(countyUrl + '/' + id).then(
						function (response) {
							var county = response.data;

							cache.put(county.Id, county);
							return county;
						}
					);
				}
			},
			remove: function (id) {
				return $http.delete(countyUrl + '/' + id).then(
					function(response){
						if(cache.get(id)) cache.remove(id);
						return response;
					}
				);
			},
			update: function (county) {
				return $http.put(countyUrl, county).then(
					function(response){
						if(cache.get(county.Id)){
							cache.remove(county.Id);
							cache.put(county.Id, county);
						}
						return response;
					});
			}
		}        
	}
})();
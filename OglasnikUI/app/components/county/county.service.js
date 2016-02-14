(function () {
	angular.module('app').factory('countyService', ['$http','API_URL', countyService]);

	function countyService($http, API_URL) {
		'use strict';

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
							q : options.query || null, 
							page : options.pageNum || 1, 
							size : options.pageSize || 20, 
							sort : options.orderBy || "name", 
							asc : options.ascending == null || !!options.ascending
						}
					}
					).then(
						function (response) {
							return response.data;
						}
					);
			},
			getById: function(id){
				return $http.get(countyUrl + '/' + id).then(
					function (response) {
						return response.data;
					}
				);
				
			},
			remove: function (id) {
				return $http.delete(countyUrl + '/' + id);
			},
			update: function (county) {
				return $http.put(countyUrl, county);
			}
		}        
	}
})();
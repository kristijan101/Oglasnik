(function () {
    angular.module('app').factory('locationService', ['$q','$http', 'CacheFactory','API_URL', locationService]);

    function locationService($q, $http, CacheFactory, API_URL) {
        'use strict';

        var cache = CacheFactory.get('locationCache')
                    || CacheFactory('locationCache', {
                            maxAge: 5 * 60 * 1000,
                            deleteOnExpire: 'aggressive'
                        });
        var locationUrl = API_URL + '/location';

        return {
            add: function (location) {
                return $http.post(locationUrl, location);
            },
            
            get: function(options){
                return $http.get(locationUrl, 
                    {
                        params: 
                        {
                            q : options.query || "", 
                            page : options.page || 1, 
                            size : options.size || 20, 
                            sort : options.orderBy || "name", 
                            asc : options.orderDirection === 'desc' ? false : true
                        }
                    }).then(
                        function (response) {
                            var locations = response.data;

                            for(var i in locations){
                                var location = locations[i];

                                if(!cache.get(location.Id)) cache.put(location.Id, location);
                            }
                            return locations;
                        }
                );
            },
            getById: function (id) {
                var location = cache.get(id);

                if(location){
                    return $q.when(location);
                }
                else 
                {
                    return $http.get(locationUrl + '/' + id).then(
                        function (response) {
                            var location = response.data;

                            cache.put(location.Id, location);
                            return location;
                        }
                    );
                }
            },
            remove: function (id) {
                return $http.delete(locationUrl + '/' + id).then(
                    function(response){
                        if(cache.get(id)) cache.remove(id);
                        return response;
                    });
            },
            //returns a comma seperated string of location names
            toString: function(locations) {                
                var temp = [];
 
                for (var i in locations) {
                    temp.push(locations[i].Name);
                }
                return temp.sort().join(', ');
            },
            update: function (location) {
                return $http.put(locationUrl, location).then(
                    function(response){
                        if(cache.get(location.Id)){
                            cache.remove(location.Id);
                            cache.put(location.Id, location);
                        }
                        return response;
                    });
            }
        }
    }
})();
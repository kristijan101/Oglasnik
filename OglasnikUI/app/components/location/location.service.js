(function () {
    angular.module('app').factory('locationService', ['$http', 'API_URL', locationService]);

    function locationService($http, API_URL) {
        'use strict';

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
                            q : options.query || null, 
                            page : options.pageNum || 1, 
                            size : options.pageSize || 20, 
                            sort : options.orderBy || "name", 
                            asc : options.ascending == null || !!options.ascending
                        }
                    }).then(
                        function (response) {
                            return response.data;
                        }
                );
            },
            getById: function (id) {
                return $http.get(locationUrl + '/' + id).then(
                    function (response) {
                        return response.data;
                    }
                );
            },
            remove: function (id) {
                return $http.delete(locationUrl + '/' + id);
            },
            //returns a delimiter seperated string of location names
            toString: function(locations, delimiter) {
                if(!angular.isArray(locations)){
                    throw new TypeError('"locations" must be an array')
                }

                delimiter = delimiter || ',';
                var temp = locations.map(function(item){
                    return item.Name;
                });
 
                return temp.sort().join(delimiter + ' ');
            },
            update: function (location) {
                return $http.put(locationUrl, location);
            }
        }
    }
})();
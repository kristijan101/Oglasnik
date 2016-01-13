(function () {
    angular.module("app").factory("locationService", ["$http", "ROUTE", locationService]);

    function locationService($http, route) {
        var _locations = [];

        return {
            addLocation: function (location) {
                return $http.post(route.LOCATION, location);
            },
            deleteLocation: function (id) {
                return $http.delete(route.LOCATION + "?id=" + id);
            },
            getAll: function(){
                return $http.get(route.LOCATION).then(
                    function (response) {
                        _locations = response.data;
                        return _locations;
                    }
                );
            },
            getById: function (id) {
                for (var i in _locations) {
                    if (_locations[i].Id === id) {
                        return _locations[i];
                    }
                }                
                return $http.get(route.LOCATION + "?id=" + id).then(
                    function (response) {
                        return response.data;
                    }
                );
            },
            getRange: function(searchString, page, size){
                return $http.get(route.LOCATION + "?search=" + searchString + "&pageNum=" + page + "&pageSize=" + size);
            },
            //returns a comma seperated string of location names
            toString: function(locations) {                
                var temp = [];
 
                for (var i in locations) {
                    temp.push(locations[i].Name);
                }
                return temp.sort().join(", ");
            },
            updateLocation: function (location) {
                return $http.put(route.LOCATION, location);
            }
        }
    }
})();
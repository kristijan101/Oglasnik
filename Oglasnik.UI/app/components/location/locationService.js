(function () {
    angular.module("app").factory("locationService", ["$http", locationService]);

    function locationService($http) {
        return {
            addLocation: function (location) {
                return $http.post("http://localhost:51102/api/location", location);
            },
            deleteLocation: function (id) {
                return $http.delete("http://localhost:51102/api/location?id=" + id);
            },
            getAll: function(){
                return $http.get("http://localhost:51102/api/location");
            },
            toString: function(locations) {
                //returns a comma seperated string of location names
                var temp = [];
 
                for (var i in locations) {
                    temp.push(locations[i].Name);
                }
                return temp.sort().join(", ");
            },
            updateLocation: function (location) {
                return $http.put("http://localhost:51102/api/location", location);
            }
        }
    }
})();
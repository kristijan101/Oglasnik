(function () {
    angular.module("app").factory("locationService", locationService);

    function locationService() {
        return {
            toString: function(locations) {
                //returns a comma seperated string of location names
                var temp = [];
 
                for (var i in locations) {
                    temp.push(locations[i].Name);
                }
                return temp.sort().join(", ");
            }
        }
    }
})();
(function () {
    angular.module("app").factory("countyService", ["$http", "ROUTE", countyService]);

    function countyService($http, route) {
        var _counties = [];

        return {
            add: function(county) {
                    return $http.post(route.COUNTY, county);
            },
            counties: function(){
                return _counties;
            },
            remove: function (id) {
                return $http.delete(route.COUNTY + "?id="+id);
            },
            get: function () {
                return $http.get(route.COUNTY).then(
                    function (response) {
                        _counties = response.data;
                        return _counties;
                    }
                    );
            },
            getById: function(id){
                for (var i in _counties) {
                    if (_counties[i].Id === id) {
                        return _counties[i];
                    }
                }
                return $http.get(route.COUNTY + "?id=" + id).then(
                    function (response) {
                        return response.data;
                    }
                );
            },
            update: function (county) {
                return $http.put(route.COUNTY, county);
            }
        }        
    }
})();
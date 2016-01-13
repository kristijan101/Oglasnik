(function () {
    angular.module("app").factory("countyService", ["$http", "ROUTE", countyService]);

    function countyService($http, route) {
        var _counties = [];

        return {
            addCounty: function(county) {
                    return $http.post(route.COUNTY, county);
            },
            counties: _counties,
            deleteCounty: function (id) {
                return $http.delete(route.COUNTY + "?id="+id);
            },
            getAll: function () {
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
            sortByName: function(a) {
                if (!$.isArray(a)) {
                    return
                }
                return a.sort(function(a, b) {
                    if (a.Name < b.Name) {
                        return -1;
                    }
                    else if (a.Name > b.Name) {
                        return 1;
                    }
                    else return 0;
                })
            },
            updateCounty: function (county) {
                return $http.put(route.COUNTY, county);
            }
        }        
    }
})();
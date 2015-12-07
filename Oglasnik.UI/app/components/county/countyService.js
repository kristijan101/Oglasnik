(function () {
    angular.module("app").factory("countyService", ["$http", countyService]);

    function countyService($http) {
        return {
            addCounty: function (county) {
                return $http.post("http://localhost:51102/api/county", county );
            },
            deleteCounty: function (id) {
                return $http.delete("http://localhost:51102/api/county?id="+id);
            },
            getCounties: function () {
                return $http.get("http://localhost:51102/api/county");
            },
            sortCounties: function (a) {
                if (!$.isArray(a)) {
                    return
                }
                return a.sort(function (a, b) {
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
                return $http.put("http://localhost:51102/api/county", county);
            }
        }
    }
})();
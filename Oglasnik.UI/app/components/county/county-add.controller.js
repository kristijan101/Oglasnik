(function() {
    angular.module("app").controller("CountyAddController", ["countyService", "$state", CountyAddController]);

    function CountyAddController(countyService, $state) {
        var vm = this;

        vm.add = add;
        vm.cancel = cancel;
        vm.county = {
            "Id" : "",
            "Name": "",
            "Locations" : []
        }

        function add(county) {
            countyService.addCounty(county).then(function(response) {
                $state.go("admin.county");                
            });
        }

        function cancel() {
            $state.go("admin.county");
        }
    }
}());
(function () {
    angular.module("app").controller("CountyEditController", ["county", "countyService", "$state", CountyEditController]);

    function CountyEditController(county, countyService, $state) {
        var vm = this;
        
        vm.cancel = cancel;
        vm.county = county;
        vm.update = update;

        function cancel() {
            $state.go("admin.county");
        }

        function update(county) {
            countyService.updateCounty(county).then(function (r) {
                $state.go("admin.county");
            })
        }
    }
}());
(function () {
    angular.module("app").controller("CountyEditController", ["county", "countyService", "$state", CountyEditController]);

    function CountyEditController(county, countyService, $state) {
        var vm = this;
        
        vm.cancel = cancel;
        vm.county = county;
        vm.update = update;

        function cancel() {
            $state.go("admin.county.list");
        }

        function update(county) {
            countyService.update(county).then(function (r) {
                $state.go("admin.county.list");
            })
        }
    }
}());
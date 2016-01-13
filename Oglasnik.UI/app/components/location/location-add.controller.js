(function(){
    angular
        .module("app")
        .controller("LocationAddController", ["$state", "locationService", "counties", LocationAddController]);

    function LocationAddController($state, locationService, counties) {
        var vm = this;

        vm.add = add;
        vm.cancel = cancel;
        vm.counties = counties;
        vm.location = {
            "Id": null,
            "Name": null,
            "CountyID": null
        };

        function add(location) {
            locationService.addLocation(location).then(function (response) {
                $state.go("admin.location");
            });
        }

        function cancel() {
            $state.go("admin.location");
        }
    }
}())
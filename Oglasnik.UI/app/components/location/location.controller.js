(function () {
    angular
        .module("app")
        .controller("LocationController", ["$state", "locationService", "locations", LocationController]);

    function LocationController($state, locationService, locations) {
        var vm = this;

        vm.locations = locations;
        vm.delete = deleteLocation;

        function deleteLocation(id, index) {
            locationService.deleteLocation(id).then(function (response) {
                $state.reload("admin.location");
            })
        }
    }
}());
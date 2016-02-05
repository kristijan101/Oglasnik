(function () {
    angular
        .module('app')
        .controller('LocationController', ['$state', 'locationService', 'locations', LocationController]);

    function LocationController($state, locationService, locations) {
        var vm = this;

        vm.locations = locations;
        vm.remove = remove;

        function remove(id) {
            locationService.remove(id).then(function (response) {
                $state.reload('admin.location.list');
            })
        }
    }
}());
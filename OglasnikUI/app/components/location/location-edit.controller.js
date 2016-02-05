(function () {
    angular
        .module('app')
        .controller('LocationEditController', ['location', 'locationService', 'counties', '$state', LocationEditController]);

    function LocationEditController(location, locationService, counties, $state) {
        var vm = this;

        vm.cancel = cancel;
        vm.counties = counties;
        vm.location = location;
        vm.update = update;
        
        function cancel() {
            $state.go('admin.location.list');
        }

        function update(location) {
            locationService.updateLocation(location).then(function(r) {
                $state.go('admin.location.list');
            })
        }
    }
}())
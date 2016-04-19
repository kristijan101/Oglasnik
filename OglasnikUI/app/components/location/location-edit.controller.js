(function (angular) {
    angular
        .module('app')
        .controller('LocationEditController', ['$q', '$state', 'countyService','locationService', LocationEditController]);

    function LocationEditController($q, $state, countyService, locationService) {
        var vm = this;

        vm.cancel = cancel;
        vm.counties = [];
        vm.location = {};
        vm.update = update;

        activate();

        function activate(){
            return $q.all({
                        counties: countyService.get({}),
                        location: locationService.getById($state.params.id)
                    }).then(function(data){
                        vm.counties = data.counties;
                        vm.location = data.location;

                        return data;
                    });
        }
        
        function cancel() {
            $state.go('admin.location.list');
        }

        function update(location) {
            locationService.update(location).then(function(r) {
                $state.go('admin.location.list');
            })
        }
    }
}(angular))
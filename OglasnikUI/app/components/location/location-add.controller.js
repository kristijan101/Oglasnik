(function(angular){
    angular
        .module('app')
        .controller('LocationAddController', ['$state', 'countyService','locationService', LocationAddController]);

    function LocationAddController($state, countyService, locationService) {
        var vm = this;

        vm.add = add;
        vm.cancel = cancel;
        vm.counties = [];
        vm.location = {
            "Id": "",
            "Name": "",
            "CountyID": null
        };

        activate();

        function activate(){
            return countyService.get({}).then(
                function(data){
                    vm.counties = data;
                    return data;
                });
        }

        function add(location) {
            locationService.add(location).then(function (response) {
                $state.go('admin.location.list');
            });
        }

        function cancel() {
            $state.go('admin.location.list');
        }
    }
}(angular))
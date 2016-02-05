(function(){
    angular
        .module('app')
        .controller('LocationAddController', ['$state', 'locationService', 'counties', LocationAddController]);

    function LocationAddController($state, locationService, counties) {
        var vm = this;

        vm.add = add;
        vm.cancel = cancel;
        vm.counties = counties;
        vm.location = {
            "Id": "",
            "Name": "",
            "CountyID": null
        };

        function add(location) {
            locationService.add(location).then(function (response) {
                $state.go('admin.location.list');
            });
        }

        function cancel() {
            $state.go('admin.location.list');
        }
    }
}())
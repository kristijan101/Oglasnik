(function () {
    angular.module('app').controller('CountyEditController', ['countyService', '$state', CountyEditController]);

    function CountyEditController(countyService, $state) {
        var vm = this;
        
        vm.cancel = cancel;
        vm.county = {};
        vm.update = update;

        activate();

        function activate(){
            countyService.getById($state.params.id).then(function(data){
                vm.county = data;
                return data;
            })
        }

        function cancel() {
            $state.go('admin.county.list');
        }

        function update(county) {
            countyService.update(county).then(function (r) {
                $state.go('admin.county.list');
            })
        }
    }
}());
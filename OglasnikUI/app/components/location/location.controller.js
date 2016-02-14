(function () {
    angular
        .module('app')
        .controller('LocationController', ['$scope', '$state', 'locationService', LocationController]);

    function LocationController($scope, $state, locationService) {
        var vm = this;

        vm.locations = [];
        vm.orderBy = 'name';
        vm.pageNum = 1;
        vm.pageSize = 20;
        vm.query = '';
        vm.remove = remove;
        vm.reverseOrder = false;

        activate();

        $scope.$watchGroup([
            function(){return vm.orderBy;},
            function(){return vm.pageNum;},
            function(){return vm.pageSize;},
            function(){return vm.reverseOrder;},
            function(){return vm.query;}
            ], 
            function(){
                get({
                    query : vm.query,
                    pageNum : vm.pageNum,
                    pageSize : vm.pageSize,
                    orderBy : vm.orderBy,
                    ascending : !vm.reverseOrder
                });
            });

        function activate(){
            return get({});
        }

        function get(options){
            return locationService.get(options).then(function(data){
                vm.locations = data;
                return data;
            });
        }

        function remove(id) {
            locationService.remove(id).then(function (response) {
                $state.reload('admin.location.list');
            })
        }
    }
}());
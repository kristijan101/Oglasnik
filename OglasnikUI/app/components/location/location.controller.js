(function (angular) {
    angular
        .module('app')
        .controller('LocationController', ['$scope', '$state', 'locationService', LocationController]);

    function LocationController($scope, $state, locationService) {
        'use strict';

        var vm = this;

        vm.currentPage = 1;
        vm.locations = [];
        vm.orderBy = 'name';      
        vm.pageSize = 20;
        vm.query = '';
        vm.remove = remove;
        vm.reverseOrder = false;

        activate();

        $scope.$watchGroup([
            function(){return vm.orderBy;},
            function(){return vm.currentPage;},
            function(){return vm.pageSize;},
            function(){return vm.reverseOrder;},
            function(){return vm.query;}
            ], 
            function(){
                get({
                    query : vm.query,
                    pageNum : vm.currentPage,
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
                vm.locations = data.Items;
                return data;
            });
        }

        function remove(id) {
            locationService.remove(id).then(function (response) {
                $state.reload('admin.location.list');
            })
        }
    }
}(angular));
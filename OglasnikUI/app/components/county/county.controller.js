(function (angular) {
    angular
        .module('app')
        .controller('CountyController', ['$scope', '$state', 'countyService', 'locationService', CountyController]);

    function CountyController($scope, $state, countyService, locationService) {
        'use strict';

        var vm = this;
        
        vm.counties = [];
        vm.currentPage = 1;                
        vm.locToString = locationsToString;
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
                get(getOptions());
            })

        function activate(){
            return get(getOptions());
        }

        function get(options){
            return countyService.get(options).then(function(data){
                vm.counties = data.Items;
                return data;
            });
        }

        function getOptions(){
            return {
                query : vm.query,
                pageNum : vm.currentPage,
                pageSize : vm.pageSize,
                orderBy : vm.orderBy,
                ascending : !vm.reverseOrder
            };
        }

        function locationsToString(a) {
            return locationService.toString(a);
        }

        function remove(id){
            countyService.remove(id).then(function(response){
                $state.reload('admin.county.list');
            })
        }             
    }
})(angular);
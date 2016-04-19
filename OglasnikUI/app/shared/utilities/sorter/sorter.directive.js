(function(angular){
	angular.module('app')
		.directive('ogSort', sort);

	function sort(){
		return {			
			bindToController: true,
			controller : ['$scope', SortController],
			controllerAs: 'sorter',
			restrict: 'A',
			scope: {
				orderBy : '=',
				reverse : '=',
				orderValue : '@'				
			},
			templateUrl: 'app/shared/utilities/sorter/sorter.directive.html',
			transclude: true	
		}

		function SortController($scope){
			var vm = this;

			vm.isOn = false;

			vm.onClick = function(){
				if(vm.orderBy === vm.orderValue){
					vm.reverse = !vm.reverse;
				}
				else {
					vm.orderBy = vm.orderValue;
					vm.reverse = false;
				}
			};

			$scope.$watch(function(){return vm.orderBy}, function(newVal){
				vm.isOn = newVal === vm.orderValue;
			});
		}
	}
}(angular))
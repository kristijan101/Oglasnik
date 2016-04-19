(function(angular){
	angular.module('app')
		.directive('ogPager', pager);

	function pager(){
		return {			
			bindToController: true,
			controller: function(){
				var vm = this;

				vm.next = function(){
					++vm.page;
				};
				vm.previous = function(){
					if(vm.page > 1){
						--vm.page;
					}						
				};
			},
			controllerAs: 'pager',
			restrict: 'E',
			scope : {
				page : '=',
				pageSize : '@'
			},
			templateUrl: 'app/shared/utilities/pager/pager.directive.html'
		}
	}
})(angular);
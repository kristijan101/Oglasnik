(function(angular){
    angular
        .module('app')
            .config(['$stateProvider', '$urlRouterProvider', RoutesConfig]);

    function RoutesConfig($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');

        //county
        $stateProvider
            .state('admin', {
                url:'/admin',
                templateUrl: 'app/shared/admin/admin.html'
            })
            .state('admin.county' ,{
                abstract: true,
                url:'/county',
                template:'<ui-view />'
            })
            .state('admin.county.list', {
                url:'',
                templateUrl: 'app/components/county/county.list.html',
                controller: 'CountyController as county'
            })
            .state('admin.county.add', {
                url: '/new',
                templateUrl: 'app/components/county/county.add.html',
                controller: 'CountyAddController as countyAdd'
            })
            .state('admin.county.edit', {
                url:'/edit/:id',
                templateUrl: 'app/components/county/county.edit.html',
                controller: 'CountyEditController as countyEdit'
            });
        //location
        $stateProvider
            .state('admin.location', {
                abstract:true,
                url:'/location',
                template:'<ui-view />'
            })
            .state('admin.location.list', {
                url:'',
                templateUrl: 'app/components/location/location.list.html',
                controller: 'LocationController as location'
            })
            .state('admin.location.add', {
                url: '/new',
                templateUrl: 'app/components/location/location.add.html',
                controller: 'LocationAddController as locationAdd'
            })
            .state('admin.location.edit', {
                url: '/edit/:id',
                templateUrl: 'app/components/location/location.edit.html',
                controller: 'LocationEditController as locationEdit'
            });
    }
})(angular)
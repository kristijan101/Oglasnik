(function(){
    angular
        .module('app', ['angular-loading-bar', 'ui.router', 'angular-cache'])
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
                controller: 'CountyController as county',
                resolve: {
                    counties: ['countyService',
                       function (countyService) {
                            return countyService.get({});
                        }
                    ]
                }
            })
            .state('admin.county.add', {
                url: '/new',
                templateUrl: 'app/components/county/county.add.html',
                controller: 'CountyAddController as countyAdd'
            })
            .state('admin.county.edit', {
                url:'/edit/:id',
                templateUrl: 'app/components/county/county.edit.html',
                controller: 'CountyEditController as countyEdit',
                resolve: {
                    county: ['countyService', '$stateParams',
                        function (countyService, $stateParams) {
                            return countyService.getById($stateParams.id);
                        }
                    ]
                }
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
                controller: 'LocationController as location',
                resolve: {
                    locations: ['locationService',
                        function (locationService) {
                            return locationService.get({});
                        }
                    ]
                }
            })
            .state('admin.location.add', {
                url: '/new',
                templateUrl: 'app/components/location/location.add.html',
                controller: 'LocationAddController as locationAdd',
                resolve: {
                    counties: ['countyService',
                        function (countyService) {
                            return countyService.get({});
                        }
                    ]
                }
            })
            .state('admin.location.edit', {
                url: '/edit/:id',
                templateUrl: 'app/components/location/location.edit.html',
                controller: 'LocationEditController as locationEdit',
                resolve: {
                    location: ['locationService', '$stateParams',
                        function (locationService, $stateParams) {
                            return locationService.getById($stateParams.id);
                        }
                    ],
                    counties: ['countyService',
                        function (countyService) {
                            return countyService.get({});
                        }
                    ]
                }
            });
    }
})()
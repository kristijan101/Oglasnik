(function(){
    angular
        .module("app", ["angular-loading-bar", "ui.router"])
            .config(["$stateProvider", "$urlRouterProvider", RoutesConfig]);

    function RoutesConfig($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/");

        //county
        $stateProvider
            .state("admin", {
                url:"/admin",
                templateUrl: "app/shared/admin/admin.html"
            })
            .state("admin.county", {
                url:"/county",
                templateUrl: "app/components/county/county.list.html",
                controller: "CountyController as county",
                resolve: {
                    counties: ["countyService",
                        function (countyService) {
                            return countyService.getAll();
                        }
                    ]
                }
            })
            .state("admin.countyAdd", {
                url: "/county/new",
                templateUrl: "app/components/county/county.add.html",
                controller: "CountyAddController as countyAdd"
            })
            .state("admin.countyEdit", {
                url:"/county/edit/:id",
                templateUrl: "app/components/county/county.edit.html",
                controller: "CountyEditController as countyEdit",
                resolve: {
                    county: ["countyService", "$stateParams",
                        function (countyService, $stateParams) {
                            return countyService.getById($stateParams.id);
                        }
                    ]
                }
            });
        //location
        $stateProvider
            .state("admin.location", {
                url: "/location",
                templateUrl: "app/components/location/location.list.html",
                controller: "LocationController as location",
                resolve: {
                    locations: ["locationService",
                        function (locationService) {
                            return locationService.getAll();
                        }
                    ]
                }
            })
            .state("admin.locationAdd", {
                url: "/location/new",
                templateUrl: "app/components/location/location.add.html",
                controller: "LocationAddController as locationAdd",
                resolve: {
                    counties: ["countyService",
                        function (countyService) {
                            return countyService.getAll();
                        }
                    ]
                }
            })
            .state("admin.locationEdit", {
                url: "/location/edit/:id",
                templateUrl: "app/components/location/location.edit.html",
                controller: "LocationEditController as locationEdit",
                resolve: {
                    location: ["locationService", "$stateParams",
                        function (locationService, $stateParams) {
                            return locationService.getById($stateParams.id);
                        }
                    ],
                    counties: ["countyService",
                        function (countyService) {
                            return countyService.getAll();
                        }
                    ]
                }
            });
    }
})()
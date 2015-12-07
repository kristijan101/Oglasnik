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
                templateUrl: "app/components/county/county.html",
                controller: "CountyController as countyCtrl"
            })
            .state("admin.county.list", {
                url: "/admin/county",
                templateUrl: "app/components/county/county.list.html"
            })
            .state("admin.county.create", {
                templateUrl: "app/components/county/county.create.html"
            })
            .state("admin.county.update", {
                templateUrl: "app/components/county/county.edit.html"
            });
        //location
        $stateProvider
            .state("admin.location", {
                templateUrl: "app/components/location/location.html",
                controller: "LocationController as locationCtrl"
            })
            .state("admin.location.list", {
                url: "/admin/location",
                templateUrl: "app/components/location/location.list.html"
            })
            .state("admin.location.create", {
                templateUrl: "app/components/location/location.create.html"
            })
            .state("admin.location.update", {
                templateUrl: "app/components/location/location.edit.html"
            });
    }
})()
(function(){
    angular
        .module("app", ["angular-loading-bar", "ui.router"])
        .config(["$stateProvider", "$urlRouterProvider", RoutesConfig]);

    function RoutesConfig($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/");

        $stateProvider
            .state("admin", {
                templateUrl: "app/shared/admin/admin.html"
            })
            .state("admin.county", {               
                templateUrl: "app/components/county/county.html",
                controller: "CountyController as countyCtrl"
            })
            .state("admin.county.list", {
                url: "/admin/county",
                templateUrl: "app/components/county/county.list.html",
            })
            .state("admin.county.create", {
                templateUrl: "app/components/county/county.create.html"
            })
            .state("admin.county.update", {
                templateUrl: "app/components/county/county.edit.html"
            });
    }
})()
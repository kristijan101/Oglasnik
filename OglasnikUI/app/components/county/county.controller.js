(function () {
    angular
        .module("app")
        .controller("CountyController", ["$state", "countyService", "counties", "locationService", CountyController]);

    function CountyController($state, countyService, counties, locationService) {
        var vm = this;
        
        vm.counties = counties;
        vm.delete = deleteCounty;        
        vm.locToString = locationsToString;     

        function deleteCounty(id){
            countyService.remove(id).then(function(response){
                $state.reload("admin.county.list");
            })
        }

        function locationsToString(a) {
            return locationService.toString(a);
        }       
    }
})();
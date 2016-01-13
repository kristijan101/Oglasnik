(function () {
    angular
        .module("app")
        .controller("CountyController", ["$state", "countyService", "counties", "locationService", CountyController]);

    function CountyController($state, countyService, counties, locationService) {
        var vm = this;
        
        vm.counties = counties;
        vm.delete = deleteCounty;        
        vm.locToString = locationsToString;     

        function deleteCounty(id, index){
            countyService.deleteCounty(id).then(function(response){
                $state.reload("admin.county");
            })
        }

        function locationsToString(a) {
            return locationService.toString(a);
        }       
    }
})();
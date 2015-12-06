(function () {
    angular.module("app").controller("CountyController", ["$state","countyService", "locationService", CountyController]);

    function CountyController($state, countyService, locationService) {
        var vm = this;
        vm.add = add;
        vm.cancel = cancel;
        vm.county = resetCountyObj();
        vm.delete = deleteCounty;
        vm.data = [];
        vm.edit = editForm;
        vm.locToString = locationsToString;
        vm.update = update;
 
        getCounties();

        function add(county) {
            countyService.addCounty(county).then(function (response) {
                $state.go("admin.county.list");
                getCounties();
                resetCountyObj();                
            });
        }

        function cancel() {
            $state.go("admin.county.list");
        }

        function deleteCounty(id){
            countyService.deleteCounty(id).then(function(response){
                getCounties();
            })
        }

        function editForm(idx) {
            var entry = vm.data[idx];
            for(var p in entry){
                vm.county[p] = entry[p];
            }
        }

        function getCounties() {
            countyService.getCounties().then(function (response) {
                var data = response.data;
                vm.data = countyService.sortCounties(data);               
            })
        }

        function locationsToString(a) {
            return locationService.toString(a);
        }

        function resetCountyObj() {
            return vm.county = { "Id": "", "Name": "", "Locations": [] };
        }

        function update(county) {
            countyService.updateCounty(county).then(function (r) {
                $state.go("admin.county.list");
                getCounties();
                resetCountyObj();
            })
        }
    }
})();
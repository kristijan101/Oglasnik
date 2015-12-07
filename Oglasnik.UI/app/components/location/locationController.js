(function () {
    angular.module("app").controller("LocationController", ["$state", "locationService", "countyService", LocationController]);

    function LocationController($state, locationService, countyService) {
        var vm = this;
        vm.add = add;
        vm.cancel = cancel;
        vm.counties = [];
        vm.location = resetLocObj();
        vm.data = [];
        vm.delete = deleteLocation;
        vm.edit = editForm;
        vm.update = update;

        getLocations();
        getCounties();

        function add(location) {
            locationService.addLocation(location).then(function (response) {
                $state.go("admin.location.list");
                getLocations();
                resetLocObj();
            });
        }

        function cancel() {
            $state.go("admin.location.list");
        }

        function deleteLocation(id) {
            locationService.deleteLocation(id).then(function (response) {
                getLocations();
            })
        }
        //prepares form for editing the selected county
        function editForm(idx) {
            var entry = vm.data[idx];
            for (var p in entry) {
                vm.location[p] = entry[p];
            }
        }

        function getCounties() {
            countyService.getCounties().then(function (response) {
                var data = response.data;

                for (var i = 0; i < data.length; i++) {
                    vm.counties[i] = data[i];
                }
            })
        }

        function getLocations() {
            locationService.getAll().then(function (response) {
                vm.data = response.data;
            });
        }

        function resetLocObj() {
            return vm.location = { "Id": null, "Name": null, "CountyID": null };
        }

        function update(location) {
            locationService.updateLocation(location).then(function (r) {
                $state.go("admin.location.list");
                getLocations();
                resetLocObj();
            })
        }
    }
})();
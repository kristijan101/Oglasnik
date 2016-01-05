(function () {
    angular
        .module("app")
        .controller("LocationController", ["$state", "locationService", "locations", LocationController]);

    function LocationController($state, locationService, locations) {
        var vm = this;

        vm.locations = locations;
        vm.delete = deleteLocation;

        //function add(location) {
        //    locationService.addLocation(location).then(function (response) {
        //        $state.go("admin.location.list");
        //        getLocations();
        //        resetLocObj();
        //    });
        //}

        //function cancel() {
        //    $state.go("admin.location.list");
        //}

        function deleteLocation(id, index) {
            locationService.deleteLocation(id).then(function (response) {
                vm.locations.splice(index, 1);
            })
        }

        //function getCounties() {
        //    countyService.getCounties().then(function (response) {
        //        var data = response.data;

        //        for (var i = 0; i < data.length; i++) {
        //            vm.counties[i] = data[i];
        //        }
        //    })
        //}

        //function getLocations() {
        //    locationService.getAll().then(function (response) {
        //        vm.data = response.data;
        //    });
        //}

        //function resetLocObj() {
        //    return vm.location = { "Id": null, "Name": null, "CountyID": null };
        //}

        //function update(location) {
        //    locationService.updateLocation(location).then(function (r) {
        //        $state.go("admin.location.list");
        //        getLocations();
        //        resetLocObj();
        //    })
        //}
    }
}());
(function () {
    var apiUrl = "http://localhost:51102/api";

    angular.module("app").constant("ROUTE", {
        COUNTY: apiUrl + "/county",
        LOCATION: apiUrl + "/location"
    });
}());
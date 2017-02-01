var MenuApp = angular.module("MenuApp", []);
MenuApp.controller("MenuController", function ($scope) {
    $scope.menu = function (e) {
        alert("menu0_click");
        var el = angular.element(".nav > li > a")[0];
        el.addClass("selected");
    };
   
})
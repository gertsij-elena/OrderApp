var OrderApp = angular.module('OrderApp', [])
.controller("OrderController", function ($scope, createService) {
    $scope.AddOrder = function () {
        //alert("works");
        var s = angular.element(document.getElementsByClassName("summa"));
        //alert("text-summa:" + s.html());
        $scope.order.Summa =s.html();        
        createService.AddOrderToDb($scope.order);
    }
})
.factory("createService", ['$http','$location', function ($http,$location) {
    var fac = {};
    fac.AddOrderToDb = function (order) {
        $http.post("/Order/Create", order).success(function (response) {
            //alert(response.status);
            window.location.href = "/Order/OrderList";

        })
        .error(function (response) {
            //alert(response.status);
            window.location.reload();
        })

    }
    return fac;
}]);
angular.element(document).ready(function () { angular.bootstrap(document.getElementById("OrderForm"), ['OrderApp']); });



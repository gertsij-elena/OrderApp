var OrderApp = angular.module('OrderApp', [])

OrderApp.controller('OrderController', function ($scope, OrderService) {
    getOrders();
    function getOrders() {
        OrderService.getOrder()
            .success(function (order) {
                //alert("success");            
                $scope.orders = order;

            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                //alert($scope.status);
            });
    };
    $scope.delete = function () {
        alert("click_delete");
        alert($scope.or.OrderId);
        OrderService.deleteOrder($scope.or.OrderId)
    };
});
OrderApp.factory('OrderService', ['$http', function ($http) {
    var OrderService = {};
    OrderService.getOrder = function () {
        return $http({
            metod:'GET',
            url: '/Order/GetOrders'
        });
    };
    //OrderService.deleteOrder = function () {
    //    return $http({
    //        metod: 'POST',
    //        url: '/Order/DeleteOrder'
    //    });
    //};
    OrderService.deleteOrder = function (id) {
        $http.post("/Order/DeleteOrder", id).success(function (response) {
            alert(response.status);
           //window.location.href = "/Order/OrderList";

        })
        .error(function (response) {
            alert(response.status);
           // window.location.reload();
        })

    }
    return OrderService;

}]);



OrderApp.filter("mydate", function () {  
    return function (x) {
        return new Date(parseInt(x.substr(6)));
    };
});
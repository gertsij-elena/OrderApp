var OrderApp = angular.module('OrderApp', ['ui.bootstrap'])

OrderApp.controller('OrderController', function ($scope, OrderService, $uibModal, $log) {
    getOrders();
    function getOrders() {
        OrderService.getOrder()
            .success(function (order) {         
                $scope.orders = order;

            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
            });
    };
    
    $scope.checked = function (order) {
       
        OrderService.editOrder(order)
        .success(function () {
            alert("Ваш заказ отправлен в архив");
        })
        .error(function (error) {
            alert("Произошла ошибка.Повторите оправку в архив");
        })
    };
    
    //modalEdit
    $scope.openEdit = function (order, size) {
        var modalInstance = $uibModal.open({
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            controllerAs: '$ctrl',
            size: size,
            resolve: {               
                order: function () {
                    return order;
                }

            }
        });
    };
    //endmodal
    //modalDelete
    $scope.openDelete = function (order, size) {
        var modalInstance = $uibModal.open({
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: 'ModalContent.html',
            controller: 'ModalInstanceCtrl',
            controllerAs: '$ctrl',
            size: size,
            resolve: {
                order: function () {
                    return order;
                }

            }
        });
    };
    //endmodal
   
});
//modalInstaneController
OrderApp.controller('ModalInstanceCtrl', function ($uibModalInstance, $scope, order) {
    var $ctrl = this;
    $scope.or = order;
    $ctrl.cancel = function () {
        $uibModalInstance.dismiss('cancel');       
    };
    $ctrl.ok = function () {
    $uibModalInstance.dismiss('cancel');
    };
});

OrderApp.component('modalComponent', {
    templateUrl: 'myModalContent.html',
    bindings: {
        resolve: '<',
        close: '&',
        dismiss: '&'
    }
});

//OrderApp.component('modal_Component', {
//    templateUrl: 'ModalContent.html',
//    bindings: {
//        resolve: '<',
//        close: '&',
//        dismiss: '&'
//    }
//});
OrderApp.factory('OrderService', ['$http', function ($http) {
    var OrderService = {};
    OrderService.getOrder = function () {
        return $http({
            metod:'GET',
            url: '/Order/GetOrders'
        });
    };
    OrderService.editOrder = function (order) {
        return $http({
            method: 'POST',
            url: '/Order/EditOrder'
        });
    };
    OrderService.editOrder = function (order) {
        return $http({
            method: 'POST',
            url: '/Order/DeleteOrder'
        });
    };
    return OrderService;

}]);



OrderApp.filter("mydate", function () {  
    return function (x) {
        return new Date(parseInt(x.substr(6)));
    };
});
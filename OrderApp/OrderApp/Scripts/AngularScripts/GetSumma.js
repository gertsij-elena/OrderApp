var ProductApp = angular.module('ProductApp', [])
.controller("ProductController", function ($scope, ProductService) {
    $scope.SelectFunction = function () {
        ProductService.getSumma($scope.product);
        };
    getProducts();
    function getProducts() {
        ProductService.getProduct()
            .success(function (product) {
                //alert("success");
               
                $scope.products = product;
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                //alert($scope.status);
            });
    }
})
ProductApp.factory('ProductService', ['$http', function ($http) {
    var ProductService = {};
    ProductService.getProduct = function () {
        return $http({
            metod: 'GET',
            url: '/Product/GetProducts'
        });
    };
    ProductService.getSumma = function (product) {
        $http.post("/Product/GetSumma", product).success(function (response) {
            var s = angular.element(document.getElementsByClassName("summa"));
            s.html(response);

        })
       .error(function (response) {
           //alert(response);
       });
       
    };
    return ProductService;
}]);



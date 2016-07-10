(function () {
    'use strict';
    angular.module('app').controller('cartCtrl', cartCtrl);

    cartCtrl.$inject = ['$scope', '$rootScope', '$timeout', '$ionicLoading', 'cartApi' ]

    function cartCtrl($scope, $rootScope, $timeout, $ionicLoading, cartApi) {           
                                  
            var products = [];
            
           if (typeof localStorage.products != 'undefined') {                
                            
              products = angular.fromJson(localStorage.products);
                            
           }

           $scope.products = products;     

           $scope.deleteCart = function (product) {
                 cartApi.deleteTocart(product);
                
           }      
    };
})();
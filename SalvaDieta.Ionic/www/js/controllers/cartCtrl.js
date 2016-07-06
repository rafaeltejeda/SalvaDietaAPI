(function () {
    'use strict';
    angular.module('app').controller('cartCtrl', cartCtrl);

    cartCtrl.$inject = ['$scope', '$rootScope', '$timeout', '$ionicLoading', 'cartApi' ]

    function cartCtrl($scope, $rootScope, $timeout, $ionicLoading, cartApi) {       
              
         
        activate()

        function activate() {
                 getProducts()     
        }

        function getProducts() {  

                // Setup the loader
                $scope.loading = $ionicLoading.show({
                      content: 'Loading',
                      template: '<p class="item-icon-center"><ion-spinner icon="lines" class="spinner-calm"></ion-spinner></p>Carregando...',
                      animation: 'fade-in',
                      showBackdrop: true,
                      maxWidth: 200,
                      showDelay: 0
                });
                        
                // Set a timeout to clear loader, however you would actually call the $scope.loading.hide(); method whenever everything is ready or loaded.
                $timeout(function () {

                        var products = [];
            
                        if (typeof localStorage.products != 'undefined') {                
                            
                            products = angular.fromJson(localStorage.products);
                            
                        }

                        $scope.products = products;    
                        
                        $ionicLoading.hide();
                }, 2000);                          
        }

        $scope.deleteCart = function (product) {
             cartApi.deleteTocart(product);
             getProducts();   
        }      
    };
})();
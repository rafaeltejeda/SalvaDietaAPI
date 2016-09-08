(function () {
    'use strict';
    angular.module('app').controller('revisaCtrl', revisaCtrl);

    revisaCtrl.$inject = ['$scope', '$timeout', '$ionicLoading',  'cartFactory']

    function revisaCtrl($scope,  $timeout, $ionicLoading, cartFactory) {

          $scope.products= [];          
          activate()

          function activate() {
              getCart();
              calculateTotal()
          }

          function calculateTotal() {
                   
                    $scope.$watch(function() {
                           var total = 0;
                           $scope.products = cartFactory.getAll();

                           angular.forEach($scope.products, function (item) {
                                    var sub = (item.quantity * item.price);
                                    total += sub;
                           });

                            
                           $scope.total = total;  
                    });

                                    
          }

          function getCart(){
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
                        $scope.$watch(function() {
                              $scope.products = cartFactory.getAll();
                        });
                        $ionicLoading.hide();
                                 
                  
            }, 2000);
          }

          $scope.remove = function (product) {
            cartFactory.remove(product);
          };
    };
})();

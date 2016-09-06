(function () {
    'use strict';
    angular.module('app').controller('cartCtrl', cartCtrl);

    cartCtrl.$inject = ['$scope', '$timeout', '$ionicLoading',  'cartFactory']

    function cartCtrl($scope,  $timeout, $ionicLoading, cartFactory) {


          activate()

          function activate() {
              getCart();
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
                        $ionicLoading.hide();
                  });                 
                  
            }, 2000);
          }

          $scope.remove = function (product) {
            cartFactory.remove(product);
          };
    };
})();

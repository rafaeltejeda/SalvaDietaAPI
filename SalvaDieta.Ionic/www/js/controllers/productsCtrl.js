(function () {
    'use strict';
    angular.module('app').controller('ProductCtrl', ProductCtrl);

    ProductCtrl.$inject = ['$scope', '$rootScope', '$location', '$state','$stateParams', '$timeout', '$ionicLoading', 'cartApi', 'productsFactory', 'cartFactory']

    function ProductCtrl($scope, $rootScope, $location, $state, $stateParams, $timeout, $ionicLoading, cartApi, productsFactory, cartFactory) {

        $scope.Products = [];
        $scope.Product = {};
        $scope.ProductsCategory = [];


        activate()

        function activate() {
            getProduct();
            getByCategoy($stateParams.id);
            getById($stateParams.id);
        }

        function getProduct() {
            productsFactory.get()
            .success(success)
            .catch(fail);

            function success(response) {

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
                            $scope.Products = response;
                            $ionicLoading.hide();
                    }, 2000);
            }

            function fail(error) {
                if (error.status == 401)
                    swal("Você não tem permissão para ver essa página", 'Requisição não autorizada.', "error");
                else
                    swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
            }
        }

        function getByCategoy(id)
        {
             productsFactory.getByCategory(id)
             .success(success)
             .catch(fail);

             function success(response) {

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
                            $scope.ProductsCategory = response;
                            $scope.CategoryTitle = response;
                            $ionicLoading.hide();
                      }, 2000);
             }

             function fail(error) {
                      if (error.status == 401)
                           swal("Você não tem permissão para ver essa página", 'Requisição não autorizada.', "error");
                      else
                      swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
            }
        }

        function getById(id)
        {
             productsFactory.getById(id)
             .success(success)
             .catch(fail);

             function success(response) {

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
                            $scope.product = response;

                            $ionicLoading.hide();
                      }, 2000);
             }

             function fail(error) {
                      if (error.status == 401)
                           swal("Você não tem permissão para ver essa página", 'Requisição não autorizada.', "error");
                      else
                      swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
            }
        }

        $scope.addCart = function(product){
            cartFactory.add(product);

            var totalItems = cartFactory.getAll().length;
            $scope.productsTotalItems = totalItems;

            $location.path('side-menu21/cesta');
        }
    };
})();

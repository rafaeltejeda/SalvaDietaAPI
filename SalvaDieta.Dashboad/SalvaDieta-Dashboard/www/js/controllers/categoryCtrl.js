(function () {
    'use strict';
    angular.module('app').controller('categoryCtrl', categoryCtrl);

    categoryCtrl.$inject = ['$scope','categoryFactory', '$timeout', '$ionicLoading']

    function categoryCtrl($scope, categoryFactory, $timeout, $ionicLoading) {       
      
        $scope.categories = [];
        
        activate()

        function activate() {
            getCategory(); 
            
              
        }
        
        function getCategory() {            
            categoryFactory.get()
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
                    $scope.categories = response;
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
    };
})();
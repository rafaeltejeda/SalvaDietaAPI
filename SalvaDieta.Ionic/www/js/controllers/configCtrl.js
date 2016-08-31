(function () {
    'use strict';
    angular.module('app').controller('configCtrl', configCtrl);

    configCtrl.$inject = ['$http', '$scope', '$rootScope', '$timeout', '$ionicLoading', '$state', '$ionicModal', 'userFactory', 'cepFactory' ]

    function configCtrl($http, $scope, $rootScope, $timeout, $ionicLoading, $state, $ionicModal, userFactory, cepFactory) {

        $scope.user = {};
        $scope.buscaCEP = getZip;
        $scope.upUser = updateUser;
    
        activate()

        function activate() {

             if ($rootScope.user == null) {
                 $state.go('login');
             }

             getByEmail();
        }

        function getZip(){
             
             var zip = $scope.user.cep;

             cepFactory.getCEP(zip)
             .success(success)
             .catch(fail);

             function success(response) {

                      // Setup the loader
                      $scope.loading = $ionicLoading.show({
                            content: 'Loading',
                            template: '<p class="item-icon-center"><ion-spinner icon="lines" class="spinner-calm"></ion-spinner></p>Carregando seus dados...',
                            animation: 'fade-in',
                            showBackdrop: true,
                            maxWidth: 200,
                            showDelay: 0
                      });

                      // Set a timeout to clear loader, however you would actually call the $scope.loading.hide(); method whenever everything is ready or loaded.
                      $timeout(function () {
                            $scope.user = response;
                            $scope.address = response.logradouro;
                            $ionicLoading.hide();
                      }, 2000);
             }

             function fail(error) {
                      if (error.status == 401)
                           swal("Você não tem permissão para ver essa página", 'Requisição não autorizada.', "error");
                      else
                      swal("Sua requisição não pode ser processada", 'o CEP está incorreto.', "error");
            }
        }


        function getByEmail(){
             userFactory.getByEmail()
             .success(success)
             .catch(fail);

             function success(response) {

                      // Setup the loader
                      $scope.loading = $ionicLoading.show({
                            content: 'Loading',
                            template: '<p class="item-icon-center"><ion-spinner icon="lines" class="spinner-calm"></ion-spinner></p>Carregando seus dados...',
                            animation: 'fade-in',
                            showBackdrop: true,
                            maxWidth: 200,
                            showDelay: 0
                      });

                      // Set a timeout to clear loader, however you would actually call the $scope.loading.hide(); method whenever everything is ready or loaded.
                      $timeout(function () {                     
                            $scope.user = response;
                            $ionicLoading.hide();
                      }, 2000);
             }

             function fail(error) {
                      if (error.status == 401)
                           $state.go('login');
                      else
                      swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
            }
        }

        function updateUser() {       

            userFactory.put($scope.user)
         
            .success(success)
            .catch(fail);

            console.log($scope.user.id);

            function success(response) {                
                swal("Parabéns", 'Alterado com secesso.', "success");
            }

            function fail(error) {                
                if (error.status == 401)
                    $state.go('login');                    
                else
                    swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
                    console.log(error);
            }
        }

    };
})();

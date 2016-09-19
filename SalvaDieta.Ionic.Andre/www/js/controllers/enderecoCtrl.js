(function () {
    'use strict';
    angular.module('app').controller('enderecoCtrl', enderecoCtrl);

    enderecoCtrl.$inject = ['$scope', '$rootScope','$state','$stateParams', '$ionicLoading', '$timeout', 'registerFactory', 'cepFactory']

    function enderecoCtrl($scope, $rootScope, $state, $stateParams, $ionicLoading, $timeout, registerFactory, cepFactory) {          
        
        $scope.user = {
              id: 0,
              address: '',
              complement: '',
              number: '',
              district: '',
              city: '',
              zip: '',
              state: '',
              cellPhone: '',            
              isAdmin: 0
        }

        $scope.buscaCEP = getZip;
        $scope.updateUser = update;      

        activate()

        function activate() {             
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
                            template: '<p class="item-icon-center"><ion-spinner icon="lines" class="spinner-calm"></ion-spinner></p>Carregando seu endereço...',
                            animation: 'fade-in',
                            showBackdrop: true,
                            maxWidth: 200,
                            showDelay: 0
                      });

                      // Set a timeout to clear loader, however you would actually call the $scope.loading.hide(); method whenever everything is ready or loaded.
                      $timeout(function () {
                            $scope.user = response;
                            $scope.address = response.logradouro;
                            console.log(response);
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

        function update() {
            
            registerFactory.put($scope.user)
            .success(success)
            .catch(fail);

            function success(response) {                
                swal("Parabéns", 'Seja Bem Vindo ao Salva Dieta.', "success");               
                $state.go('menu.home');               
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
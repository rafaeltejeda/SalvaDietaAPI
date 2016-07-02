(function () {
    'use strict';
    angular.module('app').controller('registerCtrl', registerCtrl);

    registerCtrl.$inject = ['$scope', '$state', '$timeout', '$ionicLoading', 'registerFactory']

    function registerCtrl($scope, $state, $timeout, $ionicLoading, registerFactory) {          
        
        $scope.register = {
              id: 0,
              nome: '',
              email: '',
              password: '',
              address: '',
              complement: '',
              number: '',
              district: '',
              city: '',
              zip: '',
              state: '',
              homePhone: '',
              cellPhone: '',
              photo: '',
              facebook: '',
              twitter: '',
              instagram: '',
              youTube: ''
        }

        $scope.registerUser = registerUser;

        activate()

        function activate() {           
             
        }         
        
        function registerUser() {

            
             
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
                         
                         registerFactory.post($scope.register)            
                         .success(success)
                         .catch(fail);
                          swal("Parabéns", response.nome + ' cadastrado com secesso.', "success");
                         $state.go('menu.home');
                         $ionicLoading.hide();
                }, 2000);          
            }

            function fail(error) {
                console.log(error);
                if (error.status == 401)
                    swal("Você não tem permissão para ver essa página", 'Requisição não autorizada.', "error");
                else
                    swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
            }            
        }

        function updateUser() {

            registerFactory.put($scope.register)
            .success(success)
            .catch(fail);

            function success(response) {
                console.log(response);
                swal("Parabéns", 'Produto ' + response.title + ' alterado com secesso.', "success");               
            }

            function fail(error) {
                console.log(error);
                if (error.status == 401)
                    swal("Você não tem permissão para ver essa página", 'Requisição não autorizada.', "error");
                else
                    swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
            }          
        }

    };
})();
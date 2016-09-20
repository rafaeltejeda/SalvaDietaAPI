(function () {
    'use strict';
    angular.module('app').controller('registerCtrl', registerCtrl);

    registerCtrl.$inject = ['$scope', '$rootScope','$state','$stateParams', '$ionicLoading', '$timeout', 'registerFactory']

    function registerCtrl($scope, $rootScope, $state, $stateParams, $ionicLoading, $timeout, registerFactory) {          
        
        $scope.user = {
              id: 0,
              name: '',
              email: '',
              passwordConfirmation: '',
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
              youTube: '',
              isAdmin: 0
        }

        $scope.createUser = saveUser; 

        activate()

        function activate() {           
             
        }         
        
        function addUser() {            
                 // Setup the loader
                 $scope.loading = $ionicLoading.show({
                        content: 'Loading',
                        template: '<p class="item-icon-center"><ion-spinner icon="lines" class="spinner-calm"></ion-spinner></p>Processando dados...',
                        animation: 'fade-in',
                        showBackdrop: true,
                        maxWidth: 200,
                        showDelay: 0
                 });
                      
                 // Set a timeout to clear loader, however you would actually call the $scope.loading.hide(); method whenever everything is ready or loaded.
                 $timeout(function () {                          
                          registerFactory.post($scope.user)            
                          .success(success)
                          .catch(fail);
                          $ionicLoading.hide();
                 }, 2000);       
               

            function success(response) {                        
                     $rootScope.userID = response.id;
                     $rootScope.email = response.email;
                     $rootScope.name = response.name;
                     
                     $state.go('endereco');                        
            }

            function fail(error) {
                
                if (error.status == 401)
                    swal("Você não tem permissão para ver essa página", 'Requisição não autorizada.', "error");
                else
                    swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
            }            
        }

        function saveUser() {
            
            if ($scope.user.id == 0) {
                addUser();
            } else {
                updateUsert();
            }

        }

        function updateUser() {

            registerFactory.put($scope.register)
            .success(success)
            .catch(fail);

            function success(response) {
                
                swal("Parabéns", 'Produto ' + response.title + ' alterado com secesso.', "success");               
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
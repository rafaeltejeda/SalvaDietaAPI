(function () {
    'use strict';
    angular.module('app').controller('configCtrl', configCtrl);

    configCtrl.$inject = ['$http', '$scope', '$rootScope', '$timeout', '$ionicLoading', '$state', '$ionicModal', 'userFactory', 'cepFactory' ]

    function configCtrl($http, $scope, $rootScope, $timeout, $ionicLoading, $state, $ionicModal, userFactory, cepFactory) {

        $scope.user = {};
        $scope.buscaCEP = getZip;
        $scope.saveUser = updateUser;

        activate()

        function activate() {

             if ($rootScope.user == null) {
                    $state.go('login');
             }

             getByEmail();
             getModal();

        }

        function getModal(){
              $ionicModal.fromTemplateUrl('my-modal.html', {
               scope: $scope,
               animation: 'slide-in-up'
             }).then(function(modal) {
               $scope.modal = modal;
             });

             $scope.openModal = function() {
               $scope.modal.show();
             };
             $scope.closeModal = function() {
               $scope.modal.hide();
             };
             // Cleanup the modal when we're done with it!
             $scope.$on('$destroy', function() {
               $scope.modal.remove();
             });
             // Execute action on hide modal
             $scope.$on('modal.hidden', function() {
               // Execute action
             });
             // Execute action on remove modal
             $scope.$on('modal.removed', function() {
               // Execute action
             });
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
                            debugger;
                            $scope.user = response;
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

        function addUser() {
                 // Setup the loader
                 $scope.loading = $ionicLoading.show({
                        content: 'Loading',
                        template: '<p class="item-icon-center"><ion-spinner icon="lines" class="spinner-calm"></ion-spinner></p>Cadastrando...',
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

                     console.log('teste');
                     $state.go('menu.home');
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

            console.log($scope.user);

            userFactory.put($scope.user)
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

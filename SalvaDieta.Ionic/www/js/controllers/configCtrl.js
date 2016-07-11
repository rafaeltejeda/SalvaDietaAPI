(function () {
    'use strict';
    angular.module('app').controller('configCtrl', configCtrl);

    configCtrl.$inject = ['$http', '$scope', '$rootScope', '$timeout', '$ionicLoading', '$state', '$ionicModal', 'userFactory' ]

    function configCtrl($http, $scope, $rootScope, $timeout, $ionicLoading, $state, $ionicModal, userFactory) {

        $scope.user = {
              id: 0,
              name: '',

        };

        activate()

        function activate() {

             if ($rootScope.user == null) {
                    $state.go('login');
             }

             getByEmail();

             $scope.buscaCEP = function(){
                   // Setup the loader
                   $scope.loading = $ionicLoading.show({
                         content: 'Loading',
                         template: '<p class="item-icon-center"><ion-spinner icon="lines" class="spinner-calm"></ion-spinner></p>Carregando endereço...',
                         animation: 'fade-in',
                         showBackdrop: true,
                         maxWidth: 200,
                         showDelay: 0
                   });

                   // Set a timeout to clear loader, however you would actually call the $scope.loading.hide(); method whenever everything is ready or loaded.
                   $timeout(function () {

                           $http.get('http://api.postmon.com.br/cep/'+ $scope.user.cep).success(function(local){
                                $scope.user = local;
                           });
                           $ionicLoading.hide();

                   }, 2000);
             };


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


        function getByEmail()
        {
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
                            console.log(response);
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

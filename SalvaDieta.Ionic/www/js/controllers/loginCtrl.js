'use strict';
angular.module('app').controller('loginCtrl', loginCtrl);

loginCtrl.$inject = ['$scope', '$state', '$rootScope', 'SETTINGS', '$timeout', '$ionicLoading', 'accountFactory', 'userFactory'];

function loginCtrl($scope, $state, $rootScope, SETTINGS, $timeout, $ionicLoading, accountFactory, userFactory) {

        $scope.login = {
            email: '',
            password: ''
        };

        $scope.submit = login;

        function login() {
            
            accountFactory.login($scope.login)
                .success(success)
                .catch(fail);
          
            function success(response) {
                
                $rootScope.token = response.access_token;

                localStorage.setItem(SETTINGS.AUTH_TOKEN, response.access_token);
                localStorage.setItem(SETTINGS.AUTH_USER, $rootScope.user);               
                          
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
                                                    
                                userFactory.add($scope.user);

                                $rootScope.user = response.name;

                                $ionicLoading.hide();
                        }, 2000);
                }

                function fail(error) {
                        if (error.status == 401)
                            $state.go('login');
                        else
                        swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
                }

                $state.go('menu.home');
            }           

            function fail(error) {
                swal("Falha na autenticação", error.data.error_description, "error");
            }
        }       
};

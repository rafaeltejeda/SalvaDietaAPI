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
                
                $rootScope.user = $scope.login.email;
                $rootScope.token = response.access_token;
                
                sessionStorage.setItem(SETTINGS.AUTH_TOKEN, response.access_token);                
                localStorage.setItem(SETTINGS.USER_LOGADO, $rootScope.userName);

                userFactory.getByEmail()
                .success(success)
                .catch(fail);

                function success(response) {
                        
                        $scope.user = response;                                
                        localStorage.setItem(SETTINGS.USER_NAME, response.name);
                        
                        $state.go('menu.home');
                }

                function fail(error) {
                    
                        swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
                }               
            }           

            function fail(error) {
                swal("Falha na autenticação", error.data.error_description, "error");
            }
        }       
};

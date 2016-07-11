'use strict';
angular.module('app').controller('loginCtrl', loginCtrl);

loginCtrl.$inject = ['$scope', '$state', '$rootScope', 'SETTINGS', 'accountFactory'];

function loginCtrl($scope, $state, $rootScope, SETTINGS, accountFactory) {       
        
        var authProvider = 'facebook';
        var authSettings = { 'remember': true };

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
                console.log($scope.login);              
                $rootScope.user = $scope.login.email;                
                $rootScope.token = response.access_token;

                localStorage.setItem(SETTINGS.AUTH_TOKEN, response.access_token);
                localStorage.setItem(SETTINGS.AUTH_USER, $rootScope.user);

                $state.go('menu.home');
            }

            function fail(error) {              
                swal("Falha na autenticação", error.data.error_description, "error");
            }
        } 
};
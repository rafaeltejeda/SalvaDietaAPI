(function () {
    'use strict';
    angular.module('app').controller('menuCtrl', menuCtrl);

    menuCtrl.$inject = ['$scope', '$rootScope','$state','$stateParams', '$ionicSideMenuDelegate', '$ionicActionSheet', '$ionicLoading', '$timeout', 'SETTINGS', 'userFactory', 'cartFactory']

    function menuCtrl($scope, $rootScope, $state, $stateParams, $ionicSideMenuDelegate, $ionicActionSheet, $ionicLoading, $timeout, SETTINGS, userFactory, cartFactory) {

        $scope.toggleLeft = function() {
          $ionicSideMenuDelegate.toggleLeft();
        };             
                    
        $scope.$watch(function() {
               var totalCart = 0;    
               totalCart = cartFactory.getAll().length;
               $scope.productsTotalItems = totalCart;                    
        }); 

        $scope.usuario = localStorage.getItem(SETTINGS.USER_NAME);               
    
        $scope.show = function() {

               // Show the action sheet
               var hideSheet = $ionicActionSheet.show({
                   buttons: [
                        { text: '<center><b>Sair</b></center>' }
                   ],
                   titleText: 'Deseja realmente sair?',
                   cancelText: 'Cancel',
                   cancel: function() {
                            // add cancel code..
                   },
                   buttonClicked: function(index) {
                        $rootScope.user = null;
                        $rootScope.token = null;
                        $rootScope.userName = null;
                        localStorage.removeItem(SETTINGS.AUTH_TOKEN);
                        localStorage.removeItem(SETTINGS.AUTH_USER);
                        localStorage.removeItem(SETTINGS.USER_NAME);                      

                        $state.go('login');
                   }

                });

        };  

    };
})();
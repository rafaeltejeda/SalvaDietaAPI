(function () {
    'use strict';
    angular.module('app').controller('homeCtrl', homeCtrl);

    homeCtrl.$inject = ['$scope', '$rootScope', '$state', '$timeout', '$ionicLoading' ]

    function homeCtrl($scope, $rootScope, $state, $timeout, $ionicLoading) {                                

          $scope.verificaLogin = function(){
               
               if ($rootScope.user == "null") {
                   $state.go('login');
               }else{
                   $state.go('menu.category');
               }
          }
    };
})();
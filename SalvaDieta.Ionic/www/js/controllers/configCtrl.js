(function () {
    'use strict';
    angular.module('app').controller('configCtrl', configCtrl);

    configCtrl.$inject = ['$scope', '$rootScope', '$timeout', '$ionicLoading', '$state' ]

    function configCtrl($scope, $rootScope, $timeout, $ionicLoading, $state) {       
        
        activate()

        function activate() {

             if ($rootScope.user == null) {
                    $state.go('login');
             }
        }    

         
    };
})();
angular.module('app.controllers', [])

.controller('menuCtrl', function($scope, $rootScope, $state, $ionicSideMenuDelegate, $ionicActionSheet, $timeout, SETTINGS, cartFactory) {

      $scope.toggleLeft = function() {
          $ionicSideMenuDelegate.toggleLeft();
      };             
                
      $scope.$watch(function() {
              var totalCart = 0    
              totalCart = cartFactory.getAll().length;
              $scope.productsTotalItems = totalCart;
      });

      $scope.user = $rootScope.user;

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
                localStorage.removeItem(SETTINGS.AUTH_TOKEN);
                localStorage.removeItem(SETTINGS.AUTH_USER);
                $state.go('login');
          }

        });

      };

})

.controller('homeCtrl', function($scope) {

})

.controller('loginCtrl', function($scope) {

})

.controller('localizaOCtrl', function($scope) {

})

.controller('categoriasCtrl', function($scope) {

})

.controller('categoriaFITNESSCtrl', function($scope) {

})

.controller('categoriaVEGANACtrl', function($scope) {

})

.controller('categoriaSEMGLUTENCtrl', function($scope) {

})

.controller('categoriaSEMLACTOSECtrl', function($scope) {

})

.controller('categoriaLIVRECtrl', function($scope) {

})

.controller('pGinaDoProdutoCtrl', function($scope) {

})

.controller('cestaCtrl', function($scope) {

})

.controller('agendamentoDoPedidoCtrl', function($scope) {
    $scope.IsHidden = true;
    $scope.ShowHide = function () {
           $scope.IsHidden = $scope.IsHidden ? false : true;
   }
})

.controller('revisarOPedidoCtrl', function($scope) {

})

.controller('finalizarPedidoCtrl', function($scope) {

})

.controller('histRicoCtrl', function($scope) {

})

.controller('configuraEsCtrl', function($scope) {

})

.controller('sobreCtrl', function($scope) {

})

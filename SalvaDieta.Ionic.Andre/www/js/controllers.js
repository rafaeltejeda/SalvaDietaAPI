angular.module('app.controllers', [])


.controller('loginCtrl', function($scope) {

})

.controller('localizaOCtrl', function($scope) {

})

.controller('categoriasCtrl', function($scope) {

})


.controller('agendamentoDoPedidoCtrl', function($scope) {
    $scope.IsHidden = true;
    $scope.ShowHide = function () {
           $scope.IsHidden = $scope.IsHidden ? false : true;
   }
})

.controller('finalizarPedidoCtrl', function($scope) {

})

.controller('histRicoCtrl', function($scope) {

})

.controller('configuraEsCtrl', function($scope) {

})

.controller('sobreCtrl', function($scope) {

})

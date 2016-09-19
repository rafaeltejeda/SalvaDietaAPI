(function () {
    'use strict';
    angular.module('app').controller('configCtrl', configCtrl);

    configCtrl.$inject = ['$http', '$scope', '$rootScope', '$timeout', '$ionicLoading', '$state', '$ionicModal', 'userFactory', 'cepFactory' ]

    function configCtrl($http, $scope, $rootScope, $timeout, $ionicLoading, $state, $ionicModal, userFactory, cepFactory) {
        
        $scope.user = {};
        $scope.endereco = {};
        
        $scope.buscaCEP = getZip;

        $scope.upUser = updateUser;
    
        activate()

        function activate() {

             if ($rootScope.user == null) 
                 $state.go('login');            

             getByEmail();
        }

        function getZip(){
             
             var zip = $scope.endereco.cep;

             cepFactory.getCEP(zip)
             .success(success)
             .catch(fail);

             function success(result) {
                      $scope.endereco = result;
                      $scope.address = result.logradouro;
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
                     $scope.user = response;                     
             }

             function fail(error) {
                      if (error.status == 401)
                           $state.go('login');
                      else
                      swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
            }
        }

        function updateUser() {        
            
            debugger;
            $scope.user.zip = $scope.endereco.cep;
            $scope.user.address = $scope.endereco.logradouro;
            $scope.user.number = $scope.endereco.numero;
            $scope.user.complement = $scope.endereco.complemento;
            $scope.user.district = $scope.endereco.bairro;
            $scope.user.city = $scope.endereco.cidade;
            $scope.user.state = $scope.endereco.estado;

            userFactory.put($scope.user)
         
            .success(success)
            .catch(fail);            

            function success(response) {                
                swal("Parabéns", 'Alterado com secesso.', "success");
            }

            function fail(error) {
                if (error.status == 401)
                    $state.go('login');                    
                else
                    swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");                    
            }
        }

    };
})();

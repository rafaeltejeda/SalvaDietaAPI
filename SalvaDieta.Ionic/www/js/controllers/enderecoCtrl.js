(function () {
    'use strict';
    angular.module('app').controller('enderecoCtrl', enderecoCtrl);

    enderecoCtrl.$inject = ['$scope', '$rootScope','$state','$stateParams', '$ionicLoading', '$timeout', 'registerFactory', 'cepFactory']

    function enderecoCtrl($scope, $rootScope, $state, $stateParams, $ionicLoading, $timeout, registerFactory, cepFactory) {          
        
        $scope.user = {
              id: 0,
              address: '',
              complement: '',
              number: '',
              district: '',
              city: '',
              zip: '',
              state: '',
              cellPhone: '',            
              isAdmin: 0
        }

        $scope.endereco = {}

        $scope.buscaCEP = getZip;
        $scope.updateUser = update;      

        activate()

        function activate() {             
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

        function update() {
            debugger;
            $scope.user.id = userID.value;
            $scope.user.email = $scope.user.email;

            $scope.user.zip = $scope.endereco.cep;
            $scope.user.address = $scope.endereco.logradouro;
            $scope.user.number = $scope.endereco.numero;
            $scope.user.complement = $scope.endereco.complemento;
            $scope.user.district = $scope.endereco.bairro;
            $scope.user.city = $scope.endereco.cidade;
            $scope.user.state = $scope.endereco.estado;
                    
            registerFactory.put($scope.user)
            .success(success)
            .catch(fail);

            function success(response) {                
                swal("Parabéns", 'Seja Bem Vindo ao Salva Dieta.', "success");               
                $state.go('menu.home');               
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
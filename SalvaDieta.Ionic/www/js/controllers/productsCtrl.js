(function () {
    'use strict';
    angular.module('app').controller('ProductCtrl', ProductCtrl);

    ProductCtrl.$inject = ['$scope','$stateParams', 'productsFactory']

    function ProductCtrl($scope, $stateParams, productsFactory) {       
      
        $scope.Products = [];
        $scope.ProductsCategory = [];

        activate()

        function activate() {
            getProduct(); 
            getByCategoy($stateParams.id); 
        }
        
        function getProduct() {            
            productsFactory.get()
            .success(success)
            .catch(fail);
            
            function success(response) {
                $scope.Products = response;                              
            }
            
            function fail(error) {               
                if (error.status == 401)
                    swal("Você não tem permissão para ver essa página", 'Requisição não autorizada.', "error");
                else
                    swal("Sua requisição não pode ser processada", 'Falha na requisição.', "error");
            }
        }

        function getByCategoy(id)
        {
             productsFactory.getByCategory(id)
             .success(success)
             .catch(fail);
                            

             function success(response) {
                      $scope.ProductsCategory = response;                                                         
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
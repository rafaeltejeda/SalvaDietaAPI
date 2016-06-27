(function () {
    'use strict';
    angular.module('app').controller('categoryCtrl', categoryCtrl);

    categoryCtrl.$inject = ['$scope','categoryFactory']

    function categoryCtrl($scope, categoryFactory) {       
      
        $scope.categories = [];
        
        activate()

        function activate() {
            getCategory(); 
             
        }
        
        function getCategory() {            
            categoryFactory.get()
            .success(success)
            .catch(fail);
            

            function success(response) {
                $scope.categories = response; 
                             
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
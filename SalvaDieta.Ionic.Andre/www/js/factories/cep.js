(function () {
    'use strict';
    angular.module('app').factory('cepFactory', cepFactory);

    cepFactory.$inject = ['$http', 'SETTINGS'];

    function cepFactory($http, SETTINGS) {

        return {
            getCEP: getCEP
        };

        function getCEP(data) {

          return $http.get('http://api.postmon.com.br/cep/' + data);

        }
    }
})();

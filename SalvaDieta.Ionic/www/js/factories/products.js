(function () {
    'use strict';
    angular.module('app').factory('productsFactory', productsFactory);

    productsFactory.$inject = ['$rootScope', '$http', 'SETTINGS'];

    function productsFactory($rootScope, $http, SETTINGS) {
        return {
            get: get,
            getByCategory: getByCategory
        }

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products', $rootScope.header);
        }

        function getByCategory(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products/category/' + id, $rootScope.header);
        }
    }
})();
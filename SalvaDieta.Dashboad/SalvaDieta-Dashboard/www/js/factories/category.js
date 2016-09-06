(function () {
    'use strict';
    angular.module('app').factory('categoryFactory', categoryFactory);

    categoryFactory.$inject = ['$rootScope', '$http', 'SETTINGS'];

    function categoryFactory($rootScope, $http, SETTINGS) {
        return {
            get: get
        }

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/categories', $rootScope.header);
        }
    }
})();
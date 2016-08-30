(function () {
    'use strict';
    angular.module('app').factory('registerFactory', registerFactory);

    registerFactory.$inject = ['$rootScope', '$http', 'SETTINGS'];

    function registerFactory($rootScope, $http, SETTINGS) {
        return {
            get: get,
            getById: getById,
            post: post,
            put: put,
            remove: remove
        }

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/users', $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/users/' + id, $rootScope.header);
        }

        function post(user) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/user', user, $rootScope.header);
        }

        function put(user) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/user/' + user.id, user, $rootScope.header);
        }

        function remove(user) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/user/' + user.id, $rootScope.header);
        }
    }
    
})();
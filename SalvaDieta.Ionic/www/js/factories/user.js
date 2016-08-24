(function () {
    'use strict';
    angular.module('app').factory('userFactory', userFactory);

    userFactory.$inject = ['$rootScope', '$http', 'SETTINGS'];

    function userFactory($rootScope, $http, SETTINGS) {
        return {
            get: get,
            getByEmail: getByEmail,
            put: put
        }

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/users', $rootScope.header);
        }

        function getByEmail() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/user/email', $rootScope.header);
        }

        function put(user) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/users/' + user.id, user, $rootScope.header);
        }
    }
})();

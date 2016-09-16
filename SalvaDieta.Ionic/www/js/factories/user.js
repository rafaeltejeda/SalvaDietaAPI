(function () {
    'use strict';
    angular.module('app').factory('userFactory', userFactory);

    userFactory.$inject = ['$rootScope', '$http', 'SETTINGS','$localStorage'];

    function userFactory($rootScope, $http, SETTINGS, $localStorage) {

      $localStorage = $localStorage.$default({
        user: []
      });

      var _getAll = function () {
        return $localStorage.user;
      };
      var _add = function (user) {
        $localStorage.user.push(user);
      }
      var _update = function (user) {
        $localStorage.user.push(user);
      }
      var _remove = function (user) {
        $localStorage.user.splice($localStorage.user.indexOf(user), 1);
      }

      function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/users', $rootScope.header);
      }

      function getByEmail() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/user/email', $rootScope.header);
      }

      function put(user) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/user/' + user.id, user, $rootScope.header);
      }

      return {
        getAll: _getAll,
        add: _add,
        update: _update,
        remove: _remove,
        get: get,
        getByEmail: getByEmail,
        put: put
      };

    }
})();
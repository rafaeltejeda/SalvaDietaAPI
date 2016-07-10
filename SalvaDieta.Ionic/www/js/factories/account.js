(function () {
    'use strict';
    angular.module('app').factory('accountFactory', accountFactory);

    accountFactory.$inject = ['$http', 'SETTINGS'];

    function accountFactory($http, SETTINGS) {
        
        debugger;
        
        return {
            login: login
        };

        function login(data) {
            var dt = "grant_type=password&username=" + data.email + "&password=" + data.password;
            var url = SETTINGS.SERVICE_URL + 'api/security/token';
            var header = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };

           return $http.post(url, dt, header);
        }
    }
})();
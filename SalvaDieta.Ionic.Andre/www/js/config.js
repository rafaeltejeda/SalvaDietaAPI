(function(){
    'use strict';

    angular.module('app').constant('SETTINGS', {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'AUTH_TOKEN': 'salvadieta-token',
        'AUTH_USER': 'salvadieta-user',
        'USER_NAME': 'salvadieta-userName',
        'USER_LOGADO': 'ngStorage-user',
        //'SERVICE_URL': 'http://localhost:55568/'
        'SERVICE_URL': 'http://salvadieta.azurewebsites.net/'
    });    

    angular.module('app').run(function ($rootScope, $location, SETTINGS, cartFactory) {

            var token = localStorage.getItem(SETTINGS.AUTH_TOKEN);
            var user = localStorage.getItem(SETTINGS.AUTH_USER);
            var logado = localStorage.getItem(SETTINGS.USER_LOGADO);
            var userName = localStorage.getItem(SETTINGS.USER_NAME);
            var products = localStorage.getItem(products);

            $rootScope.user = null;
            $rootScope.token = null;
            $rootScope.header = null;
            $rootScope.userName = null;
            $rootScope.logado = null;

            if (token && user) {
                $rootScope.user = user;
                $rootScope.token = token;
                $rootScope.userName = userName;
                $rootScope.logado = logado;
                
                $rootScope.header = {
                    headers: {
                        'Authorization': 'Bearer ' + $rootScope.token
                    }
                }

            }            

            $rootScope.$on("$routeChangeStart", function (event, next, current) {
                if ($rootScope.user == null) {
                    $location.path('/login');
                }
            });
    });

})();

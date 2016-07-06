(function(){
    'use strict';     

    angular.module('app').constant('SETTINGS', {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'AUTH_TOKEN': 'netzsystem-token',
        'AUTH_USER': 'netzsystem-user',
        //'SERVICE_URL': 'http://localhost:55568/'
        'SERVICE_URL': 'http://salva-dieta-api.azurewebsites.net/'        
    });

    angular.module('app').run(function ($rootScope, $window, $location, SETTINGS) {
        
             
            var token = localStorage.getItem(SETTINGS.AUTH_TOKEN);
            var user = localStorage.getItem(SETTINGS.AUTH_USER);

            $rootScope.user = null;
            $rootScope.token = null;
            $rootScope.header = null;
            
            $rootScope.user = {};

            if (token && user) {
                $rootScope.user = user;
                $rootScope.token = token;
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

            $window.fbAsyncInit = function() {
            // Executed when the SDK is loaded

            FB.init({

                    /*
                    The app id of the web app;
                    To register a new app visit Facebook App Dashboard
                    ( https://developers.facebook.com/apps/ )
                    */

                    appId: '1714871538761141',

                    /*
                    Adding a Channel File improves the performance
                    of the javascript SDK, by addressing issues
                    with cross-domain communication in certain browsers.
                    */

                    channelUrl: 'app/channel.html',

                    /*
                    Set if you want to check the authentication status
                    at the start up of the app
                    */

                    status: true,

                    /*
                    Enable cookies to allow the server to access
                    the session
                    */

                    cookie: true,

                    /* Parse XFBML */

                    xfbml: true
            });           

        };

        (function(d){
            // load the Facebook javascript SDK

            var js,
            id = 'facebook-jssdk',
            ref = d.getElementsByTagName('script')[0];

            if (d.getElementById(id)) {
            return;
            }

            js = d.createElement('script');
            js.id = id;
            js.async = true;
            js.src = "//connect.facebook.net/en_US/sdk.js";

            ref.parentNode.insertBefore(js, ref);

        }(document));
    });

})();

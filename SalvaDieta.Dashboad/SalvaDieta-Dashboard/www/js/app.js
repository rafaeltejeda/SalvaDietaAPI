
angular.module('app', ['ionic', 
                       'app.controllers', 
                       'app.routes', 
                       'app.services', 
                       'app.directives', 
                       'ngCordova', 
                       'ngStorage', 
                       'ngMessages', 
                       'ui.utils.masks'
                      ])
.run(function($ionicPlatform, $rootScope, $window) {
     $ionicPlatform.ready(function() {
     
          if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
            cordova.plugins.Keyboard.disableScroll(true);
          }

          if (window.StatusBar) {
            // org.apache.cordova.statusbar required
            StatusBar.styleDefault();
          }          

     });
})
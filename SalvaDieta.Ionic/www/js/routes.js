angular.module('app.routes', [])

.config(function($stateProvider, $urlRouterProvider) {

  // Ionic uses AngularUI Router which uses the concept of states
  // Learn more here: https://github.com/angular-ui/ui-router
  // Set up the various states which the app can be in.
  // Each state's controller can be found in controllers.js
  $stateProvider
    
  

 .state('menu.home', {
    url: '/home',
    views: {
      'side-menu21': {
        templateUrl: 'templates/home.html',
        controller: 'homeCtrl'
      }
    }
  })

  .state('login', {
    url: '/login',
    templateUrl: 'templates/login.html',
    controller: 'loginCtrl'
  })

  .state('register', {
    url: '/register',
    templateUrl: 'templates/register.html',
    controller: 'registerCtrl'
  })

  .state('menu', {
    url: '/side-menu21',
    templateUrl: 'templates/menu.html',    
    controller: 'menuCtrl',
    abstract:true
  })

  .state('menu.localizacao', {
    url: '/localizacao',
    templateUrl: 'templates/localizaO.html',
    controller: 'localizaOCtrl'
  })

  .state('menu.category', {
    url: '/category',
    views: {
      'side-menu21': {
        templateUrl: 'templates/category.html',
        controller: 'categoryCtrl'
      }
    }
  })  

  .state('menu.productsbycategory', {
    url: '/products/:id',
    views: {
      'side-menu21': {
        templateUrl: 'templates/products.html',
        controller: 'ProductCtrl'
      }
    }
  })

  .state('menu.product', {
    url: '/product/:id',
    views: {
      'side-menu21': {
        templateUrl: 'templates/product.html',
        controller: 'ProductCtrl'
      }
    }
  })

  .state('menu.cesta', {
    url: '/cesta',
    views: {
      'side-menu21': {
        templateUrl: 'templates/cesta.html',
        controller: 'cartCtrl'
      }
    }
  })

  .state('menu.agendamentoDoPedido', {
    url: '/agendamentoDoPedido',
    views: {
      'side-menu21': {
        templateUrl: 'templates/agendamentoDoPedido.html',
        controller: 'agendamentoDoPedidoCtrl'
      }
    }
  })

  .state('menu.revisarOPedido', {
    url: '/revisarPedido',
    views: {
      'side-menu21': {
        templateUrl: 'templates/revisarOPedido.html',
        controller: 'revisaCtrl'
      }
    }
  })

  .state('menu.finalizarPedido', {
    url: '/page14',
    views: {
      'side-menu21': {
        templateUrl: 'templates/finalizarPedido.html',
        controller: 'finalizarPedidoCtrl'
      }
    }
  })

  .state('menu.historico', {
    url: '/historico',
    templateUrl: 'templates/historico.html',
    controller: 'histRicoCtrl'
  })

  .state('menu.configuracoes', {
    url: '/configuracoes',
    views: {
      'side-menu21': {
        templateUrl: 'templates/configuracoes.html',
        controller: 'configCtrl'
      }
    }
  })

  .state('menu.sobre', {
    url: '/sobre',
    views: {
      'side-menu21': {
        templateUrl: 'templates/sobre.html',
        controller: 'sobreCtrl'
      }
    }
  })

$urlRouterProvider.otherwise('/side-menu21/home')  

});
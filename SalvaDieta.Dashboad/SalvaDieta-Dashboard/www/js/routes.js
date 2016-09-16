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

  .state('menu.pedidos', {
    url: '/pedidos',
    views: {
      'side-menu21': {
        templateUrl: 'templates/pedidos.html',
        controller: 'pedidosCtrl'
      }
    }
  })
  
  .state('menu.clientes', {
    url: '/clientes',
    views: {
      'side-menu21': {
        templateUrl: 'templates/clientes.html',
        controller: 'clientesCtrl'
      }
    }
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

  .state('menu.categoryId', {
    url: '/category/:id',
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

  .state('menu.descontos', {
    url: '/descontos',
    views: {
      'side-menu21': {
        templateUrl: 'templates/descontos.html',
        controller: 'descontosCtrl'
      }
    }
  })

  .state('menu.descontosId', {
    url: '/descontos/:id',
    views: {
      'side-menu21': {
        templateUrl: 'templates/descontos.html',
        controller: 'descontosCtrl'
      }
    }
  })

  .state('menu.promocoes', {
    url: '/promocoes',
    views: {
      'side-menu21': {
        templateUrl: 'templates/promocoes.html',
        controller: 'promocoesCtrl'
      }
    }
  })

  .state('menu.promocoesId', {
    url: '/promocoes/:id',
    views: {
      'side-menu21': {
        templateUrl: 'templates/promocoes.html',
        controller: 'promocoesCtrl'
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
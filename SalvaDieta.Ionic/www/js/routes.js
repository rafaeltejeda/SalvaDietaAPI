angular.module('app.routes', [])

.config(function($stateProvider, $urlRouterProvider) {

  // Ionic uses AngularUI Router which uses the concept of states
  // Learn more here: https://github.com/angular-ui/ui-router
  // Set up the various states which the app can be in.
  // Each state's controller can be found in controllers.js
  $stateProvider
    
  

      .state('menu.home', {
    url: '/page1en',
    views: {
      'side-menu21': {
        templateUrl: 'templates/home.html',
        controller: 'homeCtrl'
      }
    }
  })

  .state('login', {
    url: '/page2',
    templateUrl: 'templates/login.html',
    controller: 'loginCtrl'
  })

  .state('cadastroDoCliente', {
    url: '/page3',
    templateUrl: 'templates/cadastroDoCliente.html',
    controller: 'cadastroDoClienteCtrl'
  })

  .state('menu', {
    url: '/side-menu21',
    templateUrl: 'templates/menu.html',
    abstract:true
  })

  .state('localizaO', {
    url: '/page4',
    templateUrl: 'templates/localizaO.html',
    controller: 'localizaOCtrl'
  })

  .state('menu.categorias', {
    url: '/page5',
    views: {
      'side-menu21': {
        templateUrl: 'templates/categorias.html',
        controller: 'categoriasCtrl'
      }
    }
  })

  .state('menu.categoriaFITNESS', {
    url: '/page6',
    views: {
      'side-menu21': {
        templateUrl: 'templates/categoriaFITNESS.html',
        controller: 'categoriaFITNESSCtrl'
      }
    }
  })

  .state('menu.categoriaVEGANA', {
    url: '/page12',
    views: {
      'side-menu21': {
        templateUrl: 'templates/categoriaVEGANA.html',
        controller: 'categoriaVEGANACtrl'
      }
    }
  })

  .state('categoriaSEMGLUTEN', {
    url: '/page18',
    templateUrl: 'templates/categoriaSEMGLUTEN.html',
    controller: 'categoriaSEMGLUTENCtrl'
  })

  .state('categoriaSEMLACTOSE', {
    url: '/page19',
    templateUrl: 'templates/categoriaSEMLACTOSE.html',
    controller: 'categoriaSEMLACTOSECtrl'
  })

  .state('menu.categoriaLIVRE', {
    url: '/page13',
    views: {
      'side-menu21': {
        templateUrl: 'templates/categoriaLIVRE.html',
        controller: 'categoriaLIVRECtrl'
      }
    }
  })

  .state('menu.PaginaDoProduto', {
    url: '/page11',
    views: {
      'side-menu21': {
        templateUrl: 'templates/PaginaDoProduto.html',
        controller: 'pGinaDoProdutoCtrl'
      }
    }
  })

  .state('menu.cesta', {
    url: '/page10',
    views: {
      'side-menu21': {
        templateUrl: 'templates/cesta.html',
        controller: 'cestaCtrl'
      }
    }
  })

  .state('menu.agendamentoDoPedido', {
    url: '/page8',
    views: {
      'side-menu21': {
        templateUrl: 'templates/agendamentoDoPedido.html',
        controller: 'agendamentoDoPedidoCtrl'
      }
    }
  })

  .state('menu.revisarOPedido', {
    url: '/page9',
    views: {
      'side-menu21': {
        templateUrl: 'templates/revisarOPedido.html',
        controller: 'revisarOPedidoCtrl'
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

  .state('histRico', {
    url: '/page15',
    templateUrl: 'templates/histRico.html',
    controller: 'histRicoCtrl'
  })

  .state('menu.configuraEs', {
    url: '/page16',
    views: {
      'side-menu21': {
        templateUrl: 'templates/configuraEs.html',
        controller: 'configuraEsCtrl'
      }
    }
  })

  .state('sobre', {
    url: '/page17',
    templateUrl: 'templates/sobre.html',
    controller: 'sobreCtrl'
  })

$urlRouterProvider.otherwise('/side-menu21/page1en')

  

});
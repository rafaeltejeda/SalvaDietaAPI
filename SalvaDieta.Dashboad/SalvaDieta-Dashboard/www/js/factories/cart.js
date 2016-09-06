(function () {
    'use strict';
    angular.module('app').factory('cartFactory', cartFactory);

    cartFactory.$inject = ['$localStorage'];

    function cartFactory($localStorage) {

      $localStorage = $localStorage.$default({
        products: []
      });

      var _getAll = function () {
        return $localStorage.products;
      };
      var _add = function (products) {
        $localStorage.products.push(products);
      }
      var _remove = function (products) {
        $localStorage.products.splice($localStorage.products.indexOf(products), 1);
      }

      return {
        getAll: _getAll,
        add: _add,
        remove: _remove
      };

    }
})();

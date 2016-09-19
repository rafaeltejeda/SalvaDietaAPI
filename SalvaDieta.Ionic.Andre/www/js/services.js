angular.module('app.services', [])

.factory('BlankFactory', [function(){

}])

.service('cartApi', [function($window, $rootScope){

        this.products;
        this.total;



        this.getCart = function(){

          angular.element($window).on('storage', function(event) {
            if (event.key === 'products') {
              $rootScope.$apply();
            }
          });

            var products = [];

            if (typeof localStorage.products != 'undefined') {

                products = JSON.parse(localStorage.products);

            }

            return products;
        }

        this.getTotalItems = function () {

             var products = [];

             if (typeof localStorage.products != 'undefined') {

                 products = JSON.parse(localStorage.products);

             }

             return products;
        }

        this.addToCart = function(product) {

            var products = [];

            if (typeof localStorage.products != 'undefined'){

            var xpto = localStorage.products;
            products = JSON.parse(localStorage.products);
            }

            products.push(product)

            localStorage.setItem('products', JSON.stringify(products));

        }

        this.deleteTocart = function(product){

          angular.element($window).on('storage', function(event) {
            if (event.key === 'products') {
              $rootScope.$apply();
            }
          });

          var products = [];

          if (typeof localStorage.products != 'undefined'){
                products = JSON.parse(localStorage.products);
          }

          products = products.filter(function (products){
                return products.id !==product.id;
          });

          localStorage.setItem('products', JSON.stringify(products));
        }

}]);

angular.module('app.services', [])

.factory('BlankFactory', [function(){

}])

.service('cartApi', [function(){

        this.getCart = function(){
            
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


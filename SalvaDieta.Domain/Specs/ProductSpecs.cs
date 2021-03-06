﻿using SalvaDieta.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace SalvaDieta.Domain.Specs
{
    public static class ProductSpecs
    {
        public static Expression<Func<Product, bool>> GetProductsInStock()
        {
            return x => x.QuantityOnHand > 0;
        }

        public static Expression<Func<Product, bool>> GetProductsOutOfStock()
        {
            return x => x.QuantityOnHand == 0;
        }
    }
}

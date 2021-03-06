﻿using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Domain.Specs;
using SalvaDieta.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SalvaDieta.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private SalvaDietaDataContext _context;

        public ProductRepository(SalvaDietaDataContext context)
        {
            this._context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }        

        public List<Product> Get()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> Get(int skip, int take)
        {
            return _context.Products.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public List<Product> GetProductsInStock()
        {
            return _context.Products.Include(x => x.Category).Where(ProductSpecs.GetProductsInStock()).ToList();
        }

        public List<Product> GetProductsOutOfStock()
        {
            return _context.Products.Where(ProductSpecs.GetProductsOutOfStock()).ToList();
        }

        public List<Product> GetByCategory(int id)
        {
            return _context.Products.Where(x => x.CategoryId == id).ToList();
        }
    }
}

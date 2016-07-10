using SalvaDieta.Domain.Entities;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);

        Product Get(int id);

        List<Product> Get();
        List<Product> Get(int skip, int take);

        List<Product> GetProductsInStock();
        List<Product> GetProductsOutOfStock();
        List<Product> GetByCategory(int id);
    }
}

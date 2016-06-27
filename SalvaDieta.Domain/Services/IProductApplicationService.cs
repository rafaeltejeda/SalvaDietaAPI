using SalvaDieta.Domain.Commands.ProductCommands;
using SalvaDieta.Domain.Entities;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Services
{
    public interface IProductApplicationService
    {
        List<Product> Get();
        List<Product> GetOutOfStock();
        List<Product> Get(int skip, int take);        
        List<Product> GetByCategory(int id);

        Product Get(int id);
        Product Create(CreateProductCommand command);
        Product Update(UpdateProductCommand command);
        Product Delete(int id);
    }
}

using SalvaDieta.Domain.Commands.ProductCommands;
using SalvaDieta.Domain.Entities;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Services
{
    public interface IProductApplicationService
    {
        List<Product> Get();
        List<Product> Get(int skip, int take);
        List<Product> GetOutOfStock();

        Product Get(int id);
        Product Create(CreateProductCommand command);
        Product UpdateBasicInformation(UpdateProductCommand command);
        Product Delete(int id);
    }
}

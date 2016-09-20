using SalvaDieta.Domain.Commands.ProductCommands;
using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Domain.Services;
using SalvaDieta.Infra;
using System.Collections.Generic;

namespace SalvaDieta.ApplicationService
{
    public class ProductApplicationService : ApplicationService, IProductApplicationService
    {
        private IProductRepository _repository;
        private ICategoryRepository _categoyRepository;

        public ProductApplicationService(IProductRepository repository, ICategoryRepository categoyRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._categoyRepository = categoyRepository;
        }

        public Product Create(CreateProductCommand command)
        {
            var product = new Product(command.Title, command.Description, command.Weight ,command.Price, command.QuantityOnHand, command.CategoryId, command.Image);
            product.Register();
            _repository.Create(product);

            if (Commit())
                return product;

            return null;
        }

        public Product Update(UpdateProductCommand command)
        {
            var product = _repository.Get(command.Id);
            product.UpdateInfo(command.Title, 
                               command.Description, 
                               command.Weight, 
                               command.Price, 
                               command.QuantityOnHand, 
                               command.CategoryId, 
                               command.Image);
            _repository.Update(product);

            if (Commit())
                return product;

            return null;
        }

        public Product Delete(int id)
        {
            var product = _repository.Get(id);
            _repository.Delete(product);

            if (Commit())
                return product;

            return null;
        }       

        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Product> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public List<Product> GetOutOfStock()
        {
            return _repository.GetProductsOutOfStock();
        }

        public List<Product> Get()
        {
            return _repository.GetProductsInStock();
        }

        public List<Product> GetByCategory(int id)
        {
            return _repository.GetByCategory(id);
        }
    }
}

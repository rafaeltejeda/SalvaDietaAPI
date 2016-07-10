using SalvaDieta.Domain.Commands.CategoryCommands;
using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Domain.Services;
using SalvaDieta.Infra;
using System.Collections.Generic;

namespace SalvaDieta.ApplicationService
{
    public class CategoryApplicationService : ApplicationService, ICategoryApplicationService
    {
        private ICategoryRepository _repository;

        public CategoryApplicationService(ICategoryRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public Category Create(CreateCategoryCommand command)
        {
            var category = new Category(command.Title, command.Description, command.Icon);
            category.Register();
            _repository.Create(category);

            if (Commit())
                return category;

            return null;
        }

        public Category Update(UpdateCategoryCommand command)
        {
            var category = _repository.Get(command.Id);
            category.Update(command.Title, command.Description, command.Icon);
            _repository.Update(category);

            if (Commit())
                return category;

            return null;
        }

        public Category Delete(int id)
        {
            var category = _repository.Get(id);
            _repository.Delete(category);

            if (Commit())
                return category;

            return null;
        }

        public List<Category> Get()
        {
            return _repository.Get();
        }

        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Category> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }
    }
}

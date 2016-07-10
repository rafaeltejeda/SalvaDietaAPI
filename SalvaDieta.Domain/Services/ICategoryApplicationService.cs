using SalvaDieta.Domain.Commands.CategoryCommands;
using SalvaDieta.Domain.Entities;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Services
{
    public interface ICategoryApplicationService
    {
        List<Category> Get();
        List<Category> Get(int skip, int take);

        Category Get(int id);

        Category Create(CreateCategoryCommand command);
        Category Update(UpdateCategoryCommand command);
        Category Delete(int id);
    }
}
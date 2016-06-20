using SalvaDieta.Domain.Entities;
using SalvaDieta.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Scopes
{
    public static class CategoryScopes
    {
        public static bool CreateCategoryScopeIsValid(this Category category)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(category.Title, "O título é obrigatório"),
                AssertionConcern.AssertNotEmpty(category.Decription, "A Descrição é obrigatório"),
                AssertionConcern.AssertNotEmpty(category.Icon, "A Descrição é obrigatório")
            );
        }

        public static bool EditCategoryScopeIsValid(this Category category, string title, string decription, string icon)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(title, "O título é obrigatório"),
                AssertionConcern.AssertNotEmpty(category.Decription, "A Descrição é obrigatório"),
                AssertionConcern.AssertNotEmpty(category.Icon, "A Descrição é obrigatório")
            );
        }
    }
}

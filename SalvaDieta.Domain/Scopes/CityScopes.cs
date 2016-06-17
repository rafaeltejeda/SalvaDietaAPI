using SalvaDieta.Domain.Entities;
using SalvaDieta.SharedKernel.Validation;

namespace SalvaDieta.Domain.Scopes
{
    public static class CityScopes
    {
        public static bool CreateCityScopeIsValid(this City city)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(city.Title, "O nome da cidade é obrigatório")
            );
        }

        public static bool UpdateCityScopeIsValid(this City city, string title)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(title, "O nome da cidade é obrigatório")
            );
        }
    }
}

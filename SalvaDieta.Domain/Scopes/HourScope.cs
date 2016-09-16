using SalvaDieta.Domain.Entities;
using SalvaDieta.SharedKernel.Validation;

namespace SalvaDieta.Domain.Scopes
{
    public static class HourScope
    {
        public static bool CreateHourScopeIsValid(this Hour Hour)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(Hour.HourOfDay, "A data é obrigatório")

            );
        }

        public static bool UpdateHourScopeIsValid(this Hour Hour)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(Hour.HourOfDay, "A data é obrigatório")

            );
        }
    }
}

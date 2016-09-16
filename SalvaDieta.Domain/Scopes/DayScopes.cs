using SalvaDieta.SharedKernel.Validation;
using SalvaDieta.Domain.Entities;
using System;

namespace SalvaDieta.Domain.Scopes
{
    public static class DayScopes
    {
        public static bool CreateDayScopeIsValid(this Day Day)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(Day.DayOfWeek, "A data é obrigatório")
               
            );
        }

        public static bool UpdateDayScopeIsValid(this Day Day)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(Day.DayOfWeek, "A data é obrigatório")

            );
        }
    }
}

using SalvaDieta.Domain.Entities;
using SalvaDieta.SharedKernel.Validation;
using System.Linq;

namespace SalvaDieta.Domain.Scopes
{
    public static class OrderScopes
    {
        public static bool PlaceOrderScopeIsValid(this Order order)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertIsGreaterThan(order.OrderItems.Count(), 0, "Nenhum produto foi adicionado ao pedido")
            );
        }
    }
}

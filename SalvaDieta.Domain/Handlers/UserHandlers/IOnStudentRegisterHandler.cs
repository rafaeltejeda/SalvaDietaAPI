using SalvaDieta.Domain.Events.UserEvents;
using SalvaDieta.SharedKernel;

namespace SalvaDieta.Domain.Handlers.UserHandlers
{
    public interface IOnStudentRegisterHandler : IHandler<OnUserRegisteredEvent>
    {
    }
}

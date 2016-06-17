using SalvaDieta.Domain.Commands.UserCommands;
using SalvaDieta.Domain.Entities;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Services
{
    public interface IUserApplicationService
    {
        List<User> Get();
        List<User> Get(int skip, int take);

        User Get(int id);
        User GetByEmail(string email);

        User Authenticate(string email, string password);

        User Register(RegisterUserCommand command);
        User Update(UpdateUserCommand command);
        User Delete(int id);
    }
}

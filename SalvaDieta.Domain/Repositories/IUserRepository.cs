using SalvaDieta.Domain.Entities;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Repositories
{
    public interface IUserRepository
    {
        List<User> Get();
        List<User> Get(int skip, int take);

        User Authenticate(string email, string password);

        User Get(int id);
        User GetByEmail(string email);

        void Register(User user);
        void Update(User user);
        void Delete(User user);
    }
}

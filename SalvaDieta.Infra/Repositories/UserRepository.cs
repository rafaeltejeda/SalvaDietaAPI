using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Domain.Specs;
using SalvaDieta.Infra.Persistence.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private SalvaDietaDataContext _context;

        public UserRepository(SalvaDietaDataContext context)
        {
            this._context = context;
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }          
              
        public User Authenticate(string email, string password)
        {
            return _context.Users
                .Where(UserSpecs.AuthenticateUser(email, password))
                .FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return _context.Users
                .Where(UserSpecs.GetByEmail(email))
                .FirstOrDefault();
        }

        public List<User> Get()
        {
            return _context.Users.OrderBy(x => x.Email).ToList();
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public List<User> Get(int skip, int take)
        {
            return _context.Users.OrderBy(x => x.Email).Skip(skip).Take(take).ToList();
        }
    }
}

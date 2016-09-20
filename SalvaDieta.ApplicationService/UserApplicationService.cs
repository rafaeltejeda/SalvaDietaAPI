using SalvaDieta.Domain.Commands.UserCommands;
using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Events.UserEvents;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Domain.Services;
using SalvaDieta.Infra;
using SalvaDieta.SharedKernel.Events;
using System.Collections.Generic;


namespace SalvaDieta.ApplicationService
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public User Register(RegisterUserCommand command)
        {
            var user = new User(command.Name,
                                command.Email,
                                command.Password,
                                command.Address,
                                command.Complement,
                                command.Number,
                                command.District,
                                command.City,
                                command.Zip,
                                command.State,
                                command.Homephone,
                                command.Cellphone,
                                command.Photo,
                                command.Facebook,
                                command.Twitter,
                                command.Instagram,
                                command.YouTube
                               );
            user.Register();
            _repository.Register(user);

            if (Commit())

                DomainEvent.Raise(new OnUserRegisteredEvent(user));
                //return user;

            return user;
        }

        public User Update(UpdateUserCommand command)
        {
            var user = _repository.Get(command.Id);

            user.UpdateUser(command.Name,
                            command.Email,                            
                            command.Address,
                            command.Complement,
                            command.Number,
                            command.District,
                            command.City,
                            command.Zip,
                            command.State,
                            command.Homephone,
                            command.Cellphone,
                            command.Photo,
                            command.Facebook,
                            command.Twitter,
                            command.Instagram,
                            command.YouTube);
            _repository.Update(user);

            if (Commit())
                return user;

            return null;

        }

        public User Delete(int id)
        {
            var user = _repository.Get(id);
            _repository.Delete(user);

            if (Commit())
                return user;
            return null;
        }

        public User Authenticate(string username, string password)
        {
            return _repository.Authenticate(username, password);
        }

        public List<User> Get()
        {
            return _repository.Get();
        }

        public User GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }        

        public List<User> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public User Get(int id)
        {
            return _repository.Get(id);
        }
    }
}

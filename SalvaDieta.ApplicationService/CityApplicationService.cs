using SalvaDieta.Domain.Commands.CityCommands;
using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Domain.Services;
using SalvaDieta.Infra;
using System.Collections.Generic;

namespace SalvaDieta.ApplicationService
{
    public class CityApplicationService : ApplicationService, ICityApplicationService
    {
        private ICityRepository _repository;

        public CityApplicationService(ICityRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public City Create(CreateCityCommand command)
        {
            var city = new City(command.Title, command.IsActved);
            city.Register();
            _repository.Create(city);

            if (Commit())
                return city;

            return null;
        }

        public City Update(UpdateCityCommand command)
        {
            var city = _repository.Get(command.Id);
            city.Update(command.Title, command.IsActved);
            _repository.Update(city);

            if (Commit())
                return city;

            return null;
        }

        public City Delete(int id)
        {
            var city = _repository.Get(id);
            _repository.Delete(city);

            if (Commit())
                return city;

            return null;
        }

        public List<City> Get()
        {
            return _repository.Get();
        }

        public City Get(int id)
        {
            return _repository.Get(id);
        }

        public List<City> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }
    }
}

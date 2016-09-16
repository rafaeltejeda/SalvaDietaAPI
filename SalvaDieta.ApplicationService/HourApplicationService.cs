using SalvaDieta.Domain.Commands.HourCommands;
using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Domain.Services;
using SalvaDieta.Infra;
using SalvaDieta.Infra.Repositories;
using System.Collections.Generic;

namespace SalvaDieta.ApplicationService
{
    public class HourApplicationService : ApplicationService, IHourApplicationService
    {
        private IHourRepository _repository;
        private IDayRepository _dayRepository;

        public HourApplicationService(IHourRepository repository, IDayRepository dayRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._dayRepository = dayRepository;
        }

        public Hour Create(CreateHourCommand command)
        {
            var Hour = new Hour(command.HourOfDay, command.Active, command.Reserved, command.DayId);
            Hour.Create();
            _repository.Create(Hour);

            if (Commit())
                return Hour;

            return null;
        }

        public Hour Update(UpdateHourCommand command)
        {
            var Hour = _repository.Get(command.Id);
            Hour.Update(command.HourOfDay, command.Active, command.Reserved, command.DayId);
            _repository.Update(Hour);

            if (Commit())
                return Hour;

            return null;
        }

        public Hour Delete(int id)
        {
            var Hour = _repository.Get(id);
            _repository.Delete(Hour);

            if (Commit())
                return Hour;

            return null;
        }

        public List<Hour> Get()
        {
            return _repository.Get();
        }

        public Hour Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Hour> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }
    }
}

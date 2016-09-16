using SalvaDieta.Domain.Commands.DayCommands;
using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Domain.Services;
using SalvaDieta.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.ApplicationService
{
    public class DayApplicationService : ApplicationService, IDayApplicationService
    {
        private IDayRepository _repository;
        private IHourRepository _hourRepository;

        public DayApplicationService(IDayRepository repository, IHourRepository hourRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._hourRepository = hourRepository;
        }

        public Day Create(CreateDayCommand command)
        {
            var Day = new Day(command.DayOfWeek, command.Active, command.Reserved);
            Day.Create();
            _repository.Create(Day);

            if (Commit())
                return Day;

            return null;
        }

        public Day Update(UpdateDayCommand command)
        {
            var Day = _repository.Get(command.Id);
            Day.Update(command.DayOfWeek, command.Active, command.Reserved);
            _repository.Update(Day);

            if (Commit())
                return Day;

            return null;
        }

        public Day Delete(int id)
        {
            var Day = _repository.Get(id);
            _repository.Delete(Day);

            if (Commit())
                return Day;

            return null;
        }

        public List<Day> Get()
        {
            return _repository.Get();
        }

        public Day Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Day> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }       
    }
}

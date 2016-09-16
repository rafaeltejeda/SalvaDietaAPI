using SalvaDieta.Domain.Commands.DayCommands;
using SalvaDieta.Domain.Entities;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Services
{
    public interface IDayApplicationService
    {
        List<Day> Get();
        List<Day> Get(int skip, int take);

        Day Get(int id);

        Day Create(CreateDayCommand command);
        Day Update(UpdateDayCommand command);
        Day Delete(int id);
    }
}

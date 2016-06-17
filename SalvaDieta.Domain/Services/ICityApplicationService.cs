using SalvaDieta.Domain.Commands.CityCommands;
using SalvaDieta.Domain.Entities;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Services
{
    public interface ICityApplicationService
    {
        List<City> Get();
        List<City> Get(int skip, int take);

        City Get(int id);
        City Create(CreateCityCommand command);
        City Update(UpdateCityCommand command);
        City Delete(int id);
    }
}

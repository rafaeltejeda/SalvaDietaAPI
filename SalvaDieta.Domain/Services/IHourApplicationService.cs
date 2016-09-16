using SalvaDieta.Domain.Commands.HourCommands;
using SalvaDieta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Services
{
    public interface IHourApplicationService
    {
        List<Hour> Get();
        List<Hour> Get(int skip, int take);

        Hour Get(int id);

        Hour Create(CreateHourCommand command);
        Hour Update(UpdateHourCommand command);
        Hour Delete(int id);
    }
}

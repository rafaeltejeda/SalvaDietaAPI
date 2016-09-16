using SalvaDieta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Repositories
{
    public interface IDayRepository
    {
        void Create(Day day);
        void Update(Day day);
        void Delete(Day day);

        Day Get(int id);

        List<Day> Get();
        List<Day> Get(int skip, int take);       
    }
}

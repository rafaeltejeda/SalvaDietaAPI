using SalvaDieta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Repositories
{
    public interface IHourRepository
    {
        void Create(Hour Hour);
        void Update(Hour Hour);
        void Delete(Hour Hour);

        Hour Get(int id);

        List<Hour> Get();
        List<Hour> Get(int skip, int take);
    }
}

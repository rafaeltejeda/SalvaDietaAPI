using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Infra.Persistence.DataContexts;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace SalvaDieta.Infra.Repositories
{
    public class DayRepository : IDayRepository
    {
        private SalvaDietaDataContext _context;

        public DayRepository(SalvaDietaDataContext context)
        {
            this._context = context;
        }

        public void Create(Day day)
        {
            _context.Days.Add(day);
        }

        public void Update(Day day)
        {
            _context.Entry<Day>(day).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Day day)
        {
            _context.Days.Remove(day);
        }

        public List<Day> Get()
        {
            return _context.Days.ToList();
        }

        public Day Get(int id)
        {
            return _context.Days.Find(id);
        }

        public List<Day> Get(int skip, int take)
        {
            return _context.Days.OrderBy(x => x.DayOfWeek).Skip(skip).Take(take).ToList();
        }

    }
}

using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Linq;

namespace SalvaDieta.Infra.Repositories
{
    public class HourRepository : IHourRepository
    {
        private SalvaDietaDataContext _context;

        public HourRepository(SalvaDietaDataContext context)
        {
            this._context = context;
        }

        public void Create(Hour hour)
        {
            _context.Hours.Add(hour);
        }

        public void Update(Hour hour)
        {
            _context.Entry<Hour>(hour).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Hour hour)
        {
            _context.Hours.Remove(hour);
        }

        public List<Hour> Get()
        {
            return _context.Hours.Include("Day").ToList();
        }

        public Hour Get(int id)
        {
            return _context.Hours.Find(id);
        }

        public List<Hour> Get(int skip, int take)
        {
            return _context.Hours.OrderBy(x => x.HourOfDay).Skip(skip).Take(take).ToList();
        }

    }
}

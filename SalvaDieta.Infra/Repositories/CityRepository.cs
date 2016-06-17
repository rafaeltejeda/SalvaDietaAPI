using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SalvaDieta.Infra.Repositories
{
    public class CityRepository : ICityRepository
    {
        private SalvaDietaDataContext _context;

        public CityRepository(SalvaDietaDataContext context)
        {
            this._context = context;
        }

        public void Create(City city)
        {
            _context.Cities.Add(city);
        }

        public void Update(City city)
        {
            _context.Entry<City>(city).State = EntityState.Modified;
        }

        public void Delete(City city)
        {
            _context.Cities.Remove(city);
        }

        public List<City> Get()
        {
            return _context.Cities.ToList();
        }

        public City Get(int id)
        {
            return _context.Cities.Find(id);
        }

        public List<City> Get(int skip, int take)
        {
            return _context.Cities.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }
    }
}

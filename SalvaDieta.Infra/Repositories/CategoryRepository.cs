using SalvaDieta.Domain.Entities;
using SalvaDieta.Domain.Repositories;
using SalvaDieta.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SalvaDieta.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private SalvaDietaDataContext _context;

        public CategoryRepository(SalvaDietaDataContext context)
        {
            this._context = context;
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public List<Category> Get()
        {
            return _context.Categories.ToList();
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public List<Category> Get(int skip, int take)
        {
            return _context.Categories.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }
    }
}

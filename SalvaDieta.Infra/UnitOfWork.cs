using SalvaDieta.Infra.Persistence.DataContexts;

namespace SalvaDieta.Infra
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private SalvaDietaDataContext _context;

        public UnitOfWork(SalvaDietaDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}

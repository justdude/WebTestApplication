using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ECommerce2.Data.Common
{

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;
        private bool disposed = false;

        public UnitOfWork(IDbContextFactory contextFactory)
        {
            _context = contextFactory.GetContext();
            ContextFactory = contextFactory;
        }

        public int SaveChanges()
        {
            if (_context != null)
              return  _context.SaveChanges();

            return -1;
        }

        public async Task<int> SaveChangesAsync()
        {
            if (_context != null)
                return await _context.SaveChangesAsync();

            return -1;
        }

        public DbContext Context
        {
            get { return _context; }
        }

        public IDbContextFactory ContextFactory { get; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
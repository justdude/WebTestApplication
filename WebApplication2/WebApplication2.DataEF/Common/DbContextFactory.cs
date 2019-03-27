using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerce2.Data.Common
{

    public class DbContextFactory<T> : IDbContextFactory where T : DbContext, new()
    {
        private readonly DbContext _context;

        public DbContextFactory()
        {
            _context = new T();
        }

        public DbContext GetContext()
        {
            return _context;
        }
    }
}
using ECommerce2.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.DataEF.Repositories;

namespace WebApplication2.DataEF
{
  
    public class DatabaseService : IDatabaseService, IDisposable
    {
        private DatabaseUoW db;

        public OrderRepository OrderRepository { get; private set; }
        public CustomerRepository CustomerRepository { get; private set; }
        public ProductRepository ProductRepository { get; private set; }
        public ProductCategoryRepository ProductCategoryRepository { get; private set; }
        public DatabaseUoW UoW { get; private set; }

        public DatabaseService()
        {
            UoW = new DatabaseUoW();
            OrderRepository = new OrderRepository(UoW);
            CustomerRepository = new CustomerRepository(UoW);
            ProductRepository = new ProductRepository(UoW);
            ProductCategoryRepository = new ProductCategoryRepository(UoW);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UoW.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

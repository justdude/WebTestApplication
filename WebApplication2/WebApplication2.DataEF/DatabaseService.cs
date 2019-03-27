using ECommerce2.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.DataEF.Repositories;

namespace WebApplication2.DataEF
{
    public class DatabaseService : UnitOfWork, IUnitOfWork, IDatabaseService
    {
        public OrderRepository OrderRepository { get; private set; }
        public CustomerRepository CustomerRepository { get; private set; }
        public ProductRepository ProductRepository { get; private set; }
        public ProductCategoryRepository ProductCategoryRepository { get; private set; }

        public DatabaseService() : base(new DbContextFactory<ECommerceEntities>())
        {
            OrderRepository = new OrderRepository(this);
            CustomerRepository = new CustomerRepository(this);
            ProductRepository = new ProductRepository(this);
            ProductCategoryRepository = new ProductCategoryRepository(this);
        }

    }
}

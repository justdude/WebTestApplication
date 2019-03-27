using ECommerce2.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.DataEF.Repositories
{
    public class ProductRepository : Repository<Product>, IRepository<Product>
    {
        public ProductRepository(IUnitOfWork uow) : base(uow) { }

        public override IEnumerable<Product> GetAll()
        {
            return base.GetAll();
        }
    }
}

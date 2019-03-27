using ECommerce2.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.DataEF.Repositories
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(IUnitOfWork uow) : base(uow) { }
    }

}

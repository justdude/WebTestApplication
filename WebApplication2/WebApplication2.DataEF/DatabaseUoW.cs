using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce2.Data.Common;

namespace WebApplication2.DataEF
{
    public class DatabaseUoW : UnitOfWork, IUnitOfWork
    {
        protected DatabaseUoW(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }

        public DatabaseUoW() : base(new DbContextFactory<ECommerceEntities>())
        {

        }
    }

}

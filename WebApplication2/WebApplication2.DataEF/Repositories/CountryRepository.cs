using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce2.Data.Common;

namespace WebApplication2.DataEF.Repositories
{
    public class CountryRepository : Repository<Countrye>, IRepository<Countrye>
    {
        public CountryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

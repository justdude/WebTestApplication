using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce2.Data.Common;

namespace WebApplication2.DataEF.Repositories
{
    public class CityRepository : Repository<Citye>, IRepository<Citye>
    {
        public CityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

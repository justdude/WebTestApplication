using System.Data.Entity;
using System.Threading.Tasks;

namespace ECommerce2.Data.Common
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbContext Context { get; }
    }
}
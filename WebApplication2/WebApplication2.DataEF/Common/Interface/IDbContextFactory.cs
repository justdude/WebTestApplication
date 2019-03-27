using System.Data.Entity;

namespace ECommerce2.Data.Common
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
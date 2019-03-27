using ECommerce2.Data.Common;
using WebApplication2.DataEF.Repositories;

namespace WebApplication2.DataEF
{
    public interface IDatabaseService: IUnitOfWork
    {
        CustomerRepository CustomerRepository { get; }
        OrderRepository OrderRepository { get; }
        ProductRepository ProductRepository { get; }
        ProductCategoryRepository ProductCategoryRepository { get; }
    }
}
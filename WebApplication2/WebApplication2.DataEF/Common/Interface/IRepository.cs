using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ECommerce2.Data.Common
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T item);

        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        T Find(int ID);
        IEnumerable<T> GetAll();

        void Remove(T item);
        void Delete(int id);

        void Update(T book);

        int Save();
    }
}
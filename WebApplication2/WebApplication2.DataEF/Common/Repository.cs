using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerce2.Data.Common
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(IUnitOfWork unitOfWork)
        {
            Context = unitOfWork.Context;
        }

        public void Add(T item)
        {
            Context.Set<T>().Add(item);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public virtual T Find(int ID)
        {
            return Context.Set<T>().Find(ID);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Remove(T item)
        {
            Context.Set<T>().Remove(item);
        }

        public void Update(T book)
        {
            Context.Entry<T>(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var data = Find(id);
            if (data != null)
                Context.Set<T>().Remove(data);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
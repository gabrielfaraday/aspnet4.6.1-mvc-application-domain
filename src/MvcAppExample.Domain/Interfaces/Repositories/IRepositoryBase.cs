using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcAppExample.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Delete(Guid id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(Guid id);
        IEnumerable<TEntity> GetAll();
        int SaveChanges();
        TEntity Update(TEntity entity);
    }
}
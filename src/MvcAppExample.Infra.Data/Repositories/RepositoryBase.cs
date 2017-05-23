using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Infra.Data.Contexts;
using System.Data.Entity;
using System.Linq;

namespace MvcAppExample.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected MainContext Db;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(MainContext mainContext)
        {
            Db = mainContext;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public void Delete(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public TEntity FindById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            var entry = Db.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;

            return entity;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

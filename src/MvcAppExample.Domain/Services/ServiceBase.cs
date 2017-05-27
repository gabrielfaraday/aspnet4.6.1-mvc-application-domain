using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MvcAppExample.Domain.Services
{
    public abstract class ServiceBase<TEntity, TRepository> : IServiceBase<TEntity> where TEntity : class where TRepository : IRepositoryBase<TEntity>
    {
        protected TRepository _repository;

        public ServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public virtual TEntity FindById(Guid id)
        {
            return _repository.FindById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Delete(Guid id)
        {
            _repository.Delete(id);
        }
        
        public virtual void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

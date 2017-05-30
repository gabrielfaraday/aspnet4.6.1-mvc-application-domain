using System;
using System.Collections.Generic;
using MvcAppExample.Application.Interfaces;
using MvcAppExample.Infra.Data;
using AutoMapper;
using MvcAppExample.Domain.Interfaces.Services;
using MvcAppExample.Domain.Entities;

namespace MvcAppExample.Application.Services
{
    public abstract class AppServiceBase<TEntity, TEntityViewModel, TService> : IAppServiceBase<TEntityViewModel> where TEntity : EntityBase where TEntityViewModel : class where TService : IServiceBase<TEntity>
    {
        readonly IUnitOfWork _uow;
        protected TService _service;

        public AppServiceBase(IUnitOfWork uow, TService service)
        {
            _uow = uow;
            _service = service;
        }

        public virtual TEntityViewModel Add(TEntityViewModel entityViewModel)
        {
            var entity = _service.Add(Mapper.Map<TEntity>(entityViewModel));

            if (entity.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<TEntityViewModel>(entity);
        }

        public virtual TEntityViewModel Update(TEntityViewModel entityViewModel)
        {
            var entity = _service.Update(Mapper.Map<TEntity>(entityViewModel));

            if (entity.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<TEntityViewModel>(entity);
        }

        public virtual TEntityViewModel FindById(Guid id)
        {
            return Mapper.Map<TEntityViewModel>(_service.FindById(id));
        }

        public virtual IEnumerable<TEntityViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TEntityViewModel>>(_service.GetAll());
        }

        public virtual void Delete(Guid id)
        {
            _service.Delete(id);
            Commit();
        }

        protected void Commit()
        {
            _uow.Commit();
        }

        public virtual void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

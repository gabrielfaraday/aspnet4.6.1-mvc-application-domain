using MvcAppExample.Infra.Data.Contexts;
using System;

namespace MvcAppExample.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _mainContext;
        private bool _disposed;

        public UnitOfWork(MainContext mainContext)
        {
            _mainContext = mainContext;
            _disposed = false;
        }

        public void Commit()
        {
            _mainContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _mainContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

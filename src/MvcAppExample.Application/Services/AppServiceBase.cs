using MvcAppExample.Infra.Data.UnitOfWork;

namespace MvcAppExample.Application.Services
{
    public class AppServiceBase
    {
        readonly IUnitOfWork _uow;

        public AppServiceBase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void Commit()
        {
            _uow.Commit();
        }
    }
}

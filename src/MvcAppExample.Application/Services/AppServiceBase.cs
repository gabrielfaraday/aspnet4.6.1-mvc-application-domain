using MvcAppExample.Infra.Data;

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

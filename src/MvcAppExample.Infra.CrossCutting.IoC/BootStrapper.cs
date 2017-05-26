using MvcAppExample.Application.Interfaces;
using MvcAppExample.Application.Services;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Interfaces.Services;
using MvcAppExample.Domain.Services;
using MvcAppExample.Infra.Data;
using MvcAppExample.Infra.Data.Contexts;
using MvcAppExample.Infra.Data.Repositories;
using SimpleInjector;

namespace MvcAppExample.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            //Application Layer
            container.Register<IContatoAppService, ContatoAppService>(Lifestyle.Scoped);

            //Domain Layer
            container.Register<IContatoService, ContatoService>(Lifestyle.Scoped);

            //Data Layer
            container.Register<IContatoRepository, ContatoRepository>(Lifestyle.Scoped);
            container.Register<ITelefoneRepository, TelefoneRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<MainContext>(Lifestyle.Scoped);
        }
    }
}

using MvcAppExample.Application.Interfaces;
using MvcAppExample.Application.Services;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Interfaces.Services;
using MvcAppExample.Domain.Services;
using MvcAppExample.Infra.CrossCutting.Identity.Models;
using MvcAppExample.Infra.Data;
using MvcAppExample.Infra.Data.Contexts;
using MvcAppExample.Infra.Data.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using MvcAppExample.Infra.CrossCutting.Identity.Configurations;
using MvcAppExample.Infra.CrossCutting.Identity.Context;

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
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<MainContext>(Lifestyle.Scoped);

            //Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }
    }
}

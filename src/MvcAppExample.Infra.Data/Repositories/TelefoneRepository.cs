using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Infra.Data.Contexts;

namespace MvcAppExample.Infra.Data.Repositories
{
    public class TelefoneRepository : RepositoryBase<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}

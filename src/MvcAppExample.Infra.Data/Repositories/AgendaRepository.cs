using System.Collections.Generic;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Infra.Data.Contexts;
using System.Linq;

namespace MvcAppExample.Infra.Data.Repositories
{
    public class AgendaRepository : RepositoryBase<Contato>, IAgendaRepository
    {
        public AgendaRepository(MainContext mainContext) : base(mainContext)
        {
        }
        
        public ICollection<Contato> ObterAtivos()
        {
            return Find(c => c.Ativo).ToList();
        }

        public Contato ObterPorEmail(string email)
        {
            return Find(c => c.Email.Endereco == email).SingleOrDefault();
        }
    }
}

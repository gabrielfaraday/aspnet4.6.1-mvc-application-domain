using MvcAppExample.Domain.Entities;
using System.Collections.Generic;

namespace MvcAppExample.Domain.Interfaces.Repositories
{
    public interface IContatoRepository : IRepositoryBase<Contato>
    {
        Contato ObterPorEmail(string email);
        ICollection<Contato> ObterAtivos();
    }
}

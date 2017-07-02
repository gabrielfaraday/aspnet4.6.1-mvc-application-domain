using MvcAppExample.Domain.Entities;
using System.Collections.Generic;

namespace MvcAppExample.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}

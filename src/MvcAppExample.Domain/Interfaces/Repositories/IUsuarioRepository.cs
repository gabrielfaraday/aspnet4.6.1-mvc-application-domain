using MvcAppExample.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MvcAppExample.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}
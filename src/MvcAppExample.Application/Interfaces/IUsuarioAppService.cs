using MvcAppExample.Application.ViewModels;
using MvcAppExample.Domain.Entities;
using System.Collections.Generic;

namespace MvcAppExample.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioViewModel ObterPorId(string id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        void DesativarLock(string id);
    }
}

using MvcAppExample.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace MvcAppExample.Application.Interfaces
{
    public interface IAgendaAppService : IDisposable
    {
        ContatoViewModel Adicionar(ContatoViewModel contatoViewModel);
        ContatoViewModel Atualizar(ContatoViewModel contatoViewModel);
        void Remover(Guid id);
        ContatoViewModel ObterPorId(Guid id);
        IEnumerable<ContatoViewModel> ObterTodos();
        ContatoViewModel ObterPorEmail(string email);
        IEnumerable<ContatoViewModel> ObterAtivos();
    }
}

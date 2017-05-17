using MvcAppExample.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MvcAppExample.Domain.Interfaces.Services
{
    public interface IAgendaService : IDisposable
    {
        Contato Adicionar(Contato contato);
        Contato Atualizar(Contato contato);
        void Remover(Guid id);
        Contato ObterPorId(Guid id);
        IEnumerable<Contato> ObterTodos();
        Contato ObterPorEmail(string email);
        IEnumerable<Contato> ObterAtivos();
    }
}

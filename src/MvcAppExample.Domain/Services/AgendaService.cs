using System;
using System.Collections.Generic;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Services;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Validations.Contatos;

namespace MvcAppExample.Domain.Services
{
    public class AgendaService : IAgendaService
    {
        IAgendaRepository _agendaRepository;
        ContatoAptoParaCadastroValidation _contatoAptoParaCadastroValidation;

        public AgendaService(IAgendaRepository agendaRepository, ContatoAptoParaCadastroValidation contatoAptoParaCadastroValidation)
        {
            _agendaRepository = agendaRepository;
            _contatoAptoParaCadastroValidation = contatoAptoParaCadastroValidation;
        }

        public Contato Adicionar(Contato contato)
        {
            if (!contato.Valido())
                return contato;

            contato.ValidationResult = _contatoAptoParaCadastroValidation.Validate(contato);

            return contato.ValidationResult.IsValid
                ? _agendaRepository.Add(contato)
                : contato;
        }

        public Contato Atualizar(Contato contato)
        {
            if (!contato.Valido())
                return contato;

            return _agendaRepository.Update(contato);
        }

        public IEnumerable<Contato> ObterAtivos()
        {
            return _agendaRepository.ObterAtivos();
        }

        public Contato ObterPorEmail(string email)
        {
            return _agendaRepository.ObterPorEmail(email);
        }

        public Contato ObterPorId(Guid id)
        {
            return _agendaRepository.FindById(id);
        }

        public IEnumerable<Contato> ObterTodos()
        {
            return _agendaRepository.GetAll();
        }

        public void Remover(Guid id)
        {
            _agendaRepository.Delete(id);
        }

        public void Dispose()
        {
            _agendaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}

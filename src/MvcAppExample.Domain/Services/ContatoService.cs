using System;
using System.Collections.Generic;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Services;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Validations.Contatos;

namespace MvcAppExample.Domain.Services
{
    public class ContatoService : IContatoService
    {
        IContatoRepository _agendaRepository;
        ITelefoneRepository _telefoneRepository;

        public ContatoService(IContatoRepository agendaRepository, ITelefoneRepository telefoneRepository)
        {
            _agendaRepository = agendaRepository;
            _telefoneRepository = telefoneRepository;
        }

        public Contato Adicionar(Contato contato)
        {
            if (!contato.Validar())
                return contato;

            contato.ValidationResult = new ContatoAptoParaCadastroValidation(_agendaRepository).Validate(contato);

            return contato.ValidationResult.IsValid
                ? _agendaRepository.Add(contato)
                : contato;
        }

        public Contato Atualizar(Contato contato)
        {
            if (!contato.Validar())
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

        public Telefone AdicionarTelefone(Telefone telefone)
        {
            if (!telefone.Validar())
                return telefone;

            return _telefoneRepository.Add(telefone);
        }

        public Telefone AtualizarTelefone(Telefone telefone)
        {
            if (!telefone.Validar())
                return telefone;

            return _telefoneRepository.Update(telefone);
        }

        public Telefone ObterTelefonePorId(Guid id)
        {
            return _telefoneRepository.FindById(id);
        }

        public void RemoverTelefone(Guid id)
        {
            _telefoneRepository.Delete(id);
        }

        public void Dispose()
        {
            _agendaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

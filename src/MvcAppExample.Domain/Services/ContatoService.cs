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
        IContatoRepository _contatoRepository;
        ITelefoneRepository _telefoneRepository;

        public ContatoService(IContatoRepository contatoRepository, ITelefoneRepository telefoneRepository)
        {
            _contatoRepository = contatoRepository;
            _telefoneRepository = telefoneRepository;
        }

        public Contato Adicionar(Contato contato)
        {
            if (!contato.Validar())
                return contato;

            contato.ValidationResult = new ContatoAptoParaCadastroValidation(_contatoRepository).Validate(contato);

            contato.Ativo = true;

            return contato.ValidationResult.IsValid
                ? _contatoRepository.Add(contato)
                : contato;
        }

        public Contato Atualizar(Contato contato)
        {
            if (!contato.Validar())
                return contato;

            contato.Ativo = true;

            return _contatoRepository.Update(contato);
        }

        public IEnumerable<Contato> ObterAtivos()
        {
            return _contatoRepository.ObterAtivos();
        }

        public Contato ObterPorEmail(string email)
        {
            return _contatoRepository.ObterPorEmail(email);
        }

        public Contato ObterPorId(Guid id)
        {
            return _contatoRepository.FindById(id);
        }

        public IEnumerable<Contato> ObterTodos()
        {
            return _contatoRepository.GetAll();
        }

        public void Remover(Guid id)
        {
            _contatoRepository.Delete(id);
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
            _contatoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

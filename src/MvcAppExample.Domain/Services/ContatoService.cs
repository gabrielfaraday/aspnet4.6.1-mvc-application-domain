using System;
using System.Collections.Generic;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Services;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Validations.Contatos;

namespace MvcAppExample.Domain.Services
{
    public class ContatoService : ServiceBase<Contato, IContatoRepository>, IContatoService
    {
        IContatoRepository _contatoRepository;
        ITelefoneRepository _telefoneRepository;

        public ContatoService(IContatoRepository contatoRepository, ITelefoneRepository telefoneRepository) : base(contatoRepository)
        {
            _contatoRepository = contatoRepository;
            _telefoneRepository = telefoneRepository;
        }

        public override Contato Add(Contato contato)
        {
            if (!contato.Validar())
                return contato;

            contato.ValidationResult = new ContatoAptoParaCadastroValidation(_contatoRepository).Validate(contato);

            contato.Ativo = true;

            return contato.ValidationResult.IsValid
                ? _contatoRepository.Add(contato)
                : contato;
        }

        public override Contato Update(Contato contato)
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

        public override void Dispose()
        {
            _telefoneRepository.Dispose();
            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}

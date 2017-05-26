using System;
using System.Collections.Generic;
using MvcAppExample.Application.Interfaces;
using MvcAppExample.Application.ViewModels;
using MvcAppExample.Domain.Interfaces.Services;
using AutoMapper;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Infra.Data;

namespace MvcAppExample.Application.Services
{
    public class ContatoAppService : AppServiceBase, IContatoAppService
    {
        private readonly IContatoService _contatoService;

        public ContatoAppService(IContatoService contatoService, IUnitOfWork uow) : base(uow)
        {
            _contatoService = contatoService;
        }

        public ContatoViewModel Adicionar(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<Contato>(contatoViewModel);

            contato = _contatoService.Adicionar(contato);

            if (contato.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<ContatoViewModel>(contato);
        }

        public ContatoViewModel Atualizar(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<Contato>(contatoViewModel);

            contato = _contatoService.Atualizar(contato);

            if (contato.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<ContatoViewModel>(contato);
        }

        public IEnumerable<ContatoViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ContatoViewModel>>(_contatoService.ObterAtivos());
        }

        public ContatoViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ContatoViewModel>(_contatoService.ObterPorEmail(email));
        }

        public ContatoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ContatoViewModel>(_contatoService.ObterPorId(id));
        }

        public IEnumerable<ContatoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ContatoViewModel>>(_contatoService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _contatoService.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _contatoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public TelefoneViewModel AdicionarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = Mapper.Map<Telefone>(telefoneViewModel);

            telefone = _contatoService.AdicionarTelefone(telefone);

            if (telefone.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<TelefoneViewModel>(telefone);
        }

        public TelefoneViewModel AtualizarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = Mapper.Map<Telefone>(telefoneViewModel);

            telefone = _contatoService.AtualizarTelefone(telefone);

            if (telefone.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<TelefoneViewModel>(telefone);
        }

        public void RemoverTelefone(Guid id)
        {
            _contatoService.RemoverTelefone(id);
            Commit();
        }

        public TelefoneViewModel ObterTelefonePorId(Guid id)
        {
            return Mapper.Map<TelefoneViewModel>(_contatoService.ObterTelefonePorId(id));
        }
    }
}

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
    public class ContatoAppService : AppServiceBase<Contato, ContatoViewModel, IContatoService>, IContatoAppService
    {
        public ContatoAppService(IContatoService contatoService, IUnitOfWork uow) : base(uow, contatoService)
        {
        }

        public override ContatoViewModel Add(ContatoViewModel contatoViewModel)
        {
            var contato = _service.Add(Mapper.Map<Contato>(contatoViewModel));

            if (contato.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<ContatoViewModel>(contato);
        }

        public override ContatoViewModel Update(ContatoViewModel contatoViewModel)
        {
            var contato = _service.Update(Mapper.Map<Contato>(contatoViewModel));

            if (contato.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<ContatoViewModel>(contato);
        }

        public IEnumerable<ContatoViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ContatoViewModel>>(_service.ObterAtivos());
        }

        public ContatoViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ContatoViewModel>(_service.ObterPorEmail(email));
        }

        public TelefoneViewModel AdicionarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = _service.AdicionarTelefone(Mapper.Map<Telefone>(telefoneViewModel));

            if (telefone.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<TelefoneViewModel>(telefone);
        }

        public TelefoneViewModel AtualizarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = _service.AtualizarTelefone(Mapper.Map<Telefone>(telefoneViewModel));

            if (telefone.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<TelefoneViewModel>(telefone);
        }

        public void RemoverTelefone(Guid id)
        {
            _service.RemoverTelefone(id);
            Commit();
        }

        public TelefoneViewModel ObterTelefonePorId(Guid id)
        {
            return Mapper.Map<TelefoneViewModel>(_service.ObterTelefonePorId(id));
        }
    }
}

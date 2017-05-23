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
    public class AgendaAppService : AppServiceBase, IAgendaAppService
    {
        private readonly IAgendaService _agendaService;

        public AgendaAppService(IAgendaService agendaService, IUnitOfWork uow) : base(uow)
        {
            _agendaService = agendaService;
        }

        public ContatoViewModel Adicionar(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<Contato>(contatoViewModel);

            contato = _agendaService.Adicionar(contato);

            if (contato.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<ContatoViewModel>(contato);
        }

        public ContatoViewModel Atualizar(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<Contato>(contatoViewModel);

            contato = _agendaService.Atualizar(contato);

            if (contato.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<ContatoViewModel>(contato);
        }

        public IEnumerable<ContatoViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ContatoViewModel>>(_agendaService.ObterAtivos());
        }

        public ContatoViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ContatoViewModel>(_agendaService.ObterPorEmail(email));
        }

        public ContatoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ContatoViewModel>(_agendaService.ObterPorId(id));
        }

        public IEnumerable<ContatoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ContatoViewModel>>(_agendaService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _agendaService.Remover(id);
        }

        public void Dispose()
        {
            _agendaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

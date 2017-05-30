using System;
using System.Collections.Generic;
using MvcAppExample.Application.Interfaces;
using MvcAppExample.Application.ViewModels;
using MvcAppExample.Domain.Interfaces.Services;
using AutoMapper;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Infra.Data;
using log4net;
using System.Reflection;
using MvcAppExample.Infra.CrossCutting.AsyncServices;

namespace MvcAppExample.Application.Services
{
    public class ContatoAppService : AppServiceBase<Contato, ContatoViewModel, IContatoService>, IContatoAppService
    {
        protected static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ContatoAppService(IContatoService contatoService, IUnitOfWork uow) : base(uow, contatoService)
        {
        }

        public override IEnumerable<ContatoViewModel> GetAll()
        {
            LoggingManager.InfoLog(_logger, "Carregou todos os contatos");
            return base.GetAll();
        }

        public override ContatoViewModel Add(ContatoViewModel contatoViewModel)
        {
            var retorno = base.Add(contatoViewModel);

            if (retorno.ValidationResult.IsValid)
                retorno.ValidationResult.Message = "Contato criado com sucesso!";

            return retorno;
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

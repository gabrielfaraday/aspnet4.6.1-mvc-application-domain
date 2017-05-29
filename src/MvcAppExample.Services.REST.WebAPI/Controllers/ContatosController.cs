using MvcAppExample.Application.Interfaces;
using MvcAppExample.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MvcAppExample.Services.REST.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class ContatosController : ApiController
    {
        IContatoAppService _contatoAppService;

        public ContatosController(IContatoAppService contatoAppService)
        {
            _contatoAppService = contatoAppService;
        }

        [HttpGet]
        [Route("contatos")]
        public IEnumerable<ContatoViewModel> ObterAtivos()
        {
            return _contatoAppService.ObterAtivos();
        }

        [HttpGet]
        [Route("contatos/{id:guid}")]
        public ContatoViewModel ObterPorId(Guid id)
        {
            return _contatoAppService.FindById(id);
        }

        [HttpPost]
        [Route("contatos")]
        public void Adicionar([FromBody]ContatoViewModel contato)
        {
            _contatoAppService.Add(contato);
        }

        [HttpPut]
        [Route("contatos")]
        public void Atualizar([FromBody]ContatoViewModel contato)
        {
            _contatoAppService.Update(contato);
        }

        [HttpDelete]
        [Route("contatos")]
        public void Remover(Guid id)
        {
            _contatoAppService.Delete(id);
        }
    }
}

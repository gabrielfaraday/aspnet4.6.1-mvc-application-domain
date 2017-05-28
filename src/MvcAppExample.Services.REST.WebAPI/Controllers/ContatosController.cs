using MvcAppExample.Application.Interfaces;
using MvcAppExample.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MvcAppExample.Services.REST.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContatosController : ApiController
    {
        IContatoAppService _contatoAppService;

        public ContatosController(IContatoAppService contatoAppService)
        {
            _contatoAppService = contatoAppService;
        }

        public IEnumerable<ContatoViewModel> Get()
        {
            return _contatoAppService.GetAll();
        }

        public ContatoViewModel Get(Guid id)
        {
            return _contatoAppService.FindById(id);
        }

        public void Post([FromBody]ContatoViewModel contato)
        {
            _contatoAppService.Add(contato);
        }

        public void Put([FromBody]ContatoViewModel contato)
        {
            _contatoAppService.Update(contato);
        }

        public void Delete(Guid id)
        {
            _contatoAppService.Delete(id);
        }
    }
}

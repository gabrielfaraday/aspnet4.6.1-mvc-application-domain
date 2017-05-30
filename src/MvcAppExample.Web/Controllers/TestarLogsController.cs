using log4net;
using MvcAppExample.Application.Interfaces;
using System;
using System.Web.Mvc;

namespace MvcAppExample.Web.Controllers
{
    public class TestarLogsController : Controller
    {
        IContatoAppService _contatoAppService;

        public TestarLogsController(IContatoAppService contatoAppService)
        {
            _contatoAppService = contatoAppService;
        }

        public ActionResult Index()
        {
            var teste = _contatoAppService.GetAll();

            var logger = LogManager.GetLogger(typeof(TestarLogsController));
            logger.Warn("Atenção ...vai dar erro");

            throw new Exception("Parabéns! Você gerou uma exceção");
        }
    }
}
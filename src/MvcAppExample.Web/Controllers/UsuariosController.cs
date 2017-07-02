
using MvcAppExample.Application.Interfaces;
using System.Web.Mvc;

namespace MvcAppExample.Web.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        public ActionResult Index()
        {
            return View(_usuarioAppService.ObterTodos());
        }

        public ActionResult Details(string id)
        {
            return View(_usuarioAppService.ObterPorId(id));
        }

        public ActionResult DesativarLock(string id)
        {
            _usuarioAppService.DesativarLock(id);
            return RedirectToAction("Index");
        }
    }
}

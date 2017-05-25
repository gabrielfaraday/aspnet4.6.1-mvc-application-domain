using System;
using System.Net;
using System.Web.Mvc;
using MvcAppExample.Application.ViewModels;
using MvcAppExample.Application.Interfaces;
using MvcAppExample.Infra.CrossCutting.MvcFilters;

namespace MvcAppExample.Web.Controllers
{
    [RoutePrefix("contato")]
    [Authorize]
    public class ContatosController : Controller
    {
        readonly IContatoAppService _contatoAppService;

        public ContatosController(IContatoAppService contatoAppService)
        {
            _contatoAppService = contatoAppService;
        }

        [Route("listar")]
        [ClaimsAuthorize("ModuloContato", "CLst")]
        public ActionResult Index()
        {
            return View(_contatoAppService.ObterAtivos());
        }

        [Route("{id:guid}/detalhe")]
        [ClaimsAuthorize("ModuloContato", "CDet")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ContatoViewModel contatoViewModel = _contatoAppService.ObterPorId(id.Value);

            if (contatoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contatoViewModel);
        }

        [Route("criar")]
        [ClaimsAuthorize("ModuloContato", "CInc")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("criar")]
        [ClaimsAuthorize("ModuloContato", "CInc")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _contatoAppService.Adicionar(contatoViewModel);
                return RedirectToAction("Index");
            }

            return View(contatoViewModel);
        }

        [Route("{id:guid}/alterar")]
        [ClaimsAuthorize("ModuloContato", "CEdt")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ContatoViewModel contatoViewModel = _contatoAppService.ObterPorId(id.Value);

            if (contatoViewModel == null)
                return HttpNotFound();
            
            return View(contatoViewModel);
        }

        [Route("{id:guid}/alterar")]
        [ClaimsAuthorize("ModuloContato", "CEdt")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _contatoAppService.Atualizar(contatoViewModel);
                return RedirectToAction("Index");
            }
            return View(contatoViewModel);
        }

        [Route("{id:guid}/remover")]
        [ClaimsAuthorize("ModuloContato", "CRmv")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ContatoViewModel contatoViewModel = _contatoAppService.ObterPorId(id.Value);

            if (contatoViewModel == null)
                return HttpNotFound();
            
            return View(contatoViewModel);
        }

        [Route("{id:guid}/remover")]
        [ClaimsAuthorize("ModuloContato", "CRmv")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _contatoAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _contatoAppService.Dispose();
            
            base.Dispose(disposing);
        }
    }
}

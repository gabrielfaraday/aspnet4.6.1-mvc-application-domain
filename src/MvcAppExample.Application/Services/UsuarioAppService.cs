using AutoMapper;
using MvcAppExample.Application.Interfaces;
using MvcAppExample.Application.ViewModels;
using MvcAppExample.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace MvcAppExample.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public void DesativarLock(string id)
        {
            _usuarioService.DesativarLock(id);
        }

        public UsuarioViewModel ObterPorId(string id)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioService.ObterPorId(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioService.ObterTodos());
        }
    }
}

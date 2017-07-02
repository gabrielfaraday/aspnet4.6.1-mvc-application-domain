using System.Collections.Generic;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Services;
using MvcAppExample.Domain.Interfaces.Repositories;

namespace MvcAppExample.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void DesativarLock(string id)
        {
            _usuarioRepository.DesativarLock(id);
        }

        public Usuario ObterPorId(string id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepository.ObterTodos();
        }
    }
}

using DomainValidation.Interfaces.Specification;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;

namespace MvcAppExample.Domain.Specifications.Contatos
{
    public class ContatoPossuiEmailUnicoSpecification : ISpecification<Contato>
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoPossuiEmailUnicoSpecification(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public bool IsSatisfiedBy(Contato contato)
        {
            return _contatoRepository.ObterPorEmail(contato.Email) == null;
        }
    }
}
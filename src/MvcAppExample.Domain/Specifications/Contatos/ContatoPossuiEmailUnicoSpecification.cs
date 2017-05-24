using DomainValidation.Interfaces.Specification;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;

namespace MvcAppExample.Domain.Specifications.Contatos
{
    public class ContatoPossuiEmailUnicoSpecification : ISpecification<Contato>
    {
        private readonly IContatoRepository _agendaRepository;

        public ContatoPossuiEmailUnicoSpecification(IContatoRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public bool IsSatisfiedBy(Contato contato)
        {
            return _agendaRepository.ObterPorEmail(contato.Email) == null;
        }
    }
}
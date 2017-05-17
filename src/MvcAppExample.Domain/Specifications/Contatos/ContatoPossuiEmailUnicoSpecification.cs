using DomainValidation.Interfaces.Specification;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;

namespace MvcAppExample.Domain.Specifications.Contatos
{
    public class ContatoPossuiEmailUnicoSpecification : ISpecification<Contato>
    {
        private readonly IAgendaRepository _agendaRepository;

        public ContatoPossuiEmailUnicoSpecification(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public bool IsSatisfiedBy(Contato contato)
        {
            return _agendaRepository.ObterPorEmail(contato.Email.Endereco) == null;
        }
    }
}
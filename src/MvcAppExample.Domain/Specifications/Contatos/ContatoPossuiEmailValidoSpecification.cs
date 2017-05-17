using DomainValidation.Interfaces.Specification;
using MvcAppExample.Domain.Entities;

namespace MvcAppExample.Domain.Specifications.Contatos
{
    public class ContatoPossuiEmailValidoSpecification : ISpecification<Contato>
    {
        public bool IsSatisfiedBy(Contato contato)
        {
            return contato.Email.Validar();
        }
    }
}

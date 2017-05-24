using DomainValidation.Interfaces.Specification;
using MvcAppExample.Domain.Entities;
using System.Linq;

namespace MvcAppExample.Domain.Specifications.Contatos
{
    public class ContatoPossuiAoMenosUmTelefoneSpecification : ISpecification<Contato>
    {
        public bool IsSatisfiedBy(Contato contato)
        {
            return contato.Telefones != null && contato.Telefones.Any();
        }
    }
}

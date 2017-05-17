using DomainValidation.Interfaces.Specification;
using MvcAppExample.Domain.Entities;

namespace MvcAppExample.Domain.Specifications.Telefones
{
    public class TelefonePossuiDDDValidoSpecification : ISpecification<Telefone>
    {
        public bool IsSatisfiedBy(Telefone telefone)
        {
            return telefone.ValidarDDD();
        }
    }
}

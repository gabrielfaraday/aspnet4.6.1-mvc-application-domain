using DomainValidation.Validation;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Specifications.Telefones;

namespace MvcAppExample.Domain.Validations.Telefones
{
    public class TelefoneEstaConsistenteValidation : Validator<Telefone>
    {
        public TelefoneEstaConsistenteValidation()
        {
            var dddSpecification = new TelefonePossuiDDDValidoSpecification();
            var numeroSpecification = new TelefonePossuiNumeroValidoSpecification();

            base.Add("telefoneDDDValido", new Rule<Telefone>(dddSpecification, "DDD do telefone não é válido."));
            base.Add("telefoneNumeroValido", new Rule<Telefone>(numeroSpecification, "Número do telefone não é válido."));
        }
    }
}
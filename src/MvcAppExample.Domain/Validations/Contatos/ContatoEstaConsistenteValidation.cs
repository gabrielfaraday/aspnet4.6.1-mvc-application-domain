using DomainValidation.Validation;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Specifications.Contatos;

namespace MvcAppExample.Domain.Validations.Contatos
{
    public class ContatoEstaConsistenteValidation : Validator<Contato>
    {
        public ContatoEstaConsistenteValidation()
        {
            var emailSpecification = new ContatoPossuiEmailValidoSpecification();

            base.Add("contatoEmailValido", new Rule<Contato>(emailSpecification, "E-mail informado não é válido."));
        }
    }
}
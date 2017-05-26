using DomainValidation.Validation;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Specifications.Contatos;

namespace MvcAppExample.Domain.Validations.Contatos
{
    public class ContatoAptoParaCadastroValidation : Validator<Contato>
    {
        public ContatoAptoParaCadastroValidation(IContatoRepository contatoRepository)
        {
            var emailSpecification = new ContatoPossuiEmailUnicoSpecification(contatoRepository);

            base.Add("contatoEmailUnico", new Rule<Contato>(emailSpecification, "E-mail informado já cadastrado."));
        }
    }
}
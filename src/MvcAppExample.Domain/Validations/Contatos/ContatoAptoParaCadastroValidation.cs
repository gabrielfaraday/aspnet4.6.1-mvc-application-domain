using DomainValidation.Validation;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Specifications.Contatos;

namespace MvcAppExample.Domain.Validations.Contatos
{
    public class ContatoAptoParaCadastroValidation : Validator<Contato>
    {
        public ContatoAptoParaCadastroValidation(IContatoRepository agendaRepository)
        {
            var emailSpecification = new ContatoPossuiEmailUnicoSpecification(agendaRepository);
            var telefoneSpecification = new ContatoPossuiAoMenosUmTelefoneSpecification();

            base.Add("contatoEmailUnico", new Rule<Contato>(emailSpecification, "E-mail informado já cadastrado."));
            base.Add("contatoPossuiTelefone", new Rule<Contato>(telefoneSpecification, "Contato deve ter ao menos um telefone."));
        }
    }
}
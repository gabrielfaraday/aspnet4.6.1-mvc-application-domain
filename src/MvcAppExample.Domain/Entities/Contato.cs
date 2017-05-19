using DomainValidation.Validation;
using MvcAppExample.Domain.Validations.Contatos;
using MvcAppExample.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace MvcAppExample.Domain.Entities
{
    public class Contato
    {
        public Contato()
        {
            ContatoId = Guid.NewGuid();
            Telefones = new List<Telefone>();
        }

        public Guid ContatoId { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual bool Validar()
        {
            ValidationResult = new ContatoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

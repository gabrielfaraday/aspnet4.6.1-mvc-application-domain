using DomainValidation.Validation;
using MvcAppExample.Domain.Validations.Contatos;
using MvcAppExample.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace MvcAppExample.Domain.Entities
{
    public class Contato
    {
        ContatoEstaConsistenteValidation _contatoEstaConsistenteValidation;

        public Contato(ContatoEstaConsistenteValidation contatoEstaConsistenteValidation)
        {
            ContatoId = Guid.NewGuid();
            Telefones = new List<Telefone>();
            _contatoEstaConsistenteValidation = contatoEstaConsistenteValidation;
        }

        public Guid ContatoId { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool Valido()
        {
            ValidationResult = _contatoEstaConsistenteValidation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

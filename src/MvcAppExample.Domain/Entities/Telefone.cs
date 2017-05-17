using DomainValidation.Validation;
using MvcAppExample.Domain.Validations.Telefones;
using System;
using System.Text.RegularExpressions;

namespace MvcAppExample.Domain.Entities
{
    public class Telefone
    {
        TelefoneEstaConsistenteValidation _telefoneEstaConsistenteValidation;

        public Telefone(TelefoneEstaConsistenteValidation telefoneEstaConsistenteValidation)
        {
            TelefoneId = Guid.NewGuid();
            _telefoneEstaConsistenteValidation = telefoneEstaConsistenteValidation;
        }

        public Guid TelefoneId { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
        public Guid ContatoId { get; set; }
        public virtual Contato Contato { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool Validar()
        {
            ValidationResult = _telefoneEstaConsistenteValidation.Validate(this);
            return ValidationResult.IsValid;
        }

        internal bool ValidarDDD()
        {
            return Regex.IsMatch(DDD.ToString(), @"\A([0-9]2)\Z");
        }

        internal bool ValidarNumero()
        {
            return Regex.IsMatch(DDD.ToString(), @"\A([0-9]8)\Z");
        }
    }
}

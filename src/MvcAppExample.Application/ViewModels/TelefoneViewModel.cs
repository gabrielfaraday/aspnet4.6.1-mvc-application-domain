using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcAppExample.Application.ViewModels
{
    public class TelefoneViewModel
    {
        public TelefoneViewModel()
        {
            TelefoneId = Guid.NewGuid();
        }

        [Key]
        public Guid TelefoneId { get; set; }

        [Required(ErrorMessage = "Informe o DDD do telefone")]
        [StringLength(2, ErrorMessage = "Deve ter 2 caracteres")]
        public int DDD { get; set; }

        [Required(ErrorMessage = "Informe o número do telefone")]
        [MaxLength(9, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(8, ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("Número")]
        public int Numero { get; set; }

        [ScaffoldColumn(false)]
        public Guid ContatoId { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

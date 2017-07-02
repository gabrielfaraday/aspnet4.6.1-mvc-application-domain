using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcAppExample.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        [MaxLength(256, ErrorMessage = "Máximo 256 caracteres")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        [DisplayName("E-mail")]
        public virtual string Email { get; set; }

        [DisplayName("E-mail confirmado")]
        public virtual bool EmailConfirmed { get; set; }

        [DisplayName("Senha")]
        public virtual string PasswordHash { get; set; }

        [DisplayName("Stamp")]
        public virtual string SecurityStamp { get; set; }

        [DisplayName("Stamp")]
        public virtual string PhoneNumber { get; set; }

        [DisplayName("Telefone")]
        public virtual bool PhoneNumberConfirmed { get; set; }

        [DisplayName("Possui validação de 2 passos")]
        public virtual bool TwoFactorEnabled { get; set; }

        [DisplayName("Data Fim do lockout")]
        public virtual DateTime? LockoutEndDateUtc { get; set; }

        [DisplayName("Lockout Habilitado")]
        public virtual bool LockoutEnabled { get; set; }

        [DisplayName("Tentativas falhas")]
        public virtual int AccessFailedCount { get; set; }

        [Required(ErrorMessage = "Informe o username")]
        [MaxLength(256, ErrorMessage = "Máximo 256 caracteres")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido para o username")]
        [DisplayName("user name")]
        public virtual string UserName { get; set; }
    }
}
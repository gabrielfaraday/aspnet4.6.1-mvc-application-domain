using System.ComponentModel.DataAnnotations;

namespace MvcAppExample.Infra.CrossCutting.Identity.Account.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

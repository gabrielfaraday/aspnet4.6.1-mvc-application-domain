using System.ComponentModel.DataAnnotations;

namespace MvcAppExample.Infra.CrossCutting.Identity.Account.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

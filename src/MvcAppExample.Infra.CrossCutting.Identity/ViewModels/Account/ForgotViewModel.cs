using System.ComponentModel.DataAnnotations;

namespace MvcAppExample.Infra.CrossCutting.Identity.Account.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

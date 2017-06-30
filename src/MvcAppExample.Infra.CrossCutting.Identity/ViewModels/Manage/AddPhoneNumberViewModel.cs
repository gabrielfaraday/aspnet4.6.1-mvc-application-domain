using System.ComponentModel.DataAnnotations;

namespace MvcAppExample.Infra.CrossCutting.Identity.ViewModels.Manage
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}

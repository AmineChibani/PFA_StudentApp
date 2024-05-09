using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email est obligatoire")]
        [Display(Name = "Eamil du compte")]
        public string email { get; set; }
        [Required(ErrorMessage = "Mot de passe est obligatoire")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

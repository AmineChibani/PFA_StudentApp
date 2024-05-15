using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModels.Admin
{
    public class LockScreenVM
    {
        [Required(ErrorMessage = "Mot de passe est obligatoire")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

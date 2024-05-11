using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModels.Admin
{
    public class ProfileSettingsAdminVM
    {
        [Required(ErrorMessage = "Nom est obligatoire.")]
        public string Nom { get; set; } = null!;

        [Required(ErrorMessage = "Prenom est obligatoire.")]
        public string Prenom { get; set; } = null!;

        [Required(ErrorMessage = "Email est obligatoire.")]
        public string Email { get; set; } = null!;

    }
}

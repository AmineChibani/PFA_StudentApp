using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModels
{
    public class AddStudentViewModel
    {
        public int IdStudent { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le CEN est requis.")]
        public string Cen { get; set; }

        [Required(ErrorMessage = "Le CIN est requis.")]
        public string Cin { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "L'adresse est requise.")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas au bon format.")]
        public string Email { get; set; }

        public string? Password { get; set; }

        [Display(Name = "État")]
        public bool Etat { get; set; } = true;

        [Required(ErrorMessage = "Le Cartier est requis.")]
        public int CartierId { get; set; }
    }
}

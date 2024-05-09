using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModels.Student
{
    public class StudentViewModel
    {

        public int IdStudent { get; set; }

        [Required(ErrorMessage = "Nom is required")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Prenom is required")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Cen is required")]
        public string Cen { get; set; }

        [Required(ErrorMessage = "Cin is required")]
        public string Cin { get; set; }

        [Required(ErrorMessage = "Tel is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid telephone number")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Adresse is required")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        public bool Etat { get; set; } = true;

        [Required(ErrorMessage = "Cartier is required")]
        public int Cartier { get; set; }
    }

}


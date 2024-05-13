using Microsoft.AspNetCore.Mvc.Rendering;
using StudentApp.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModels.Ads
{

    public enum Os
    {
        Ios,
        Android,
        Windows
    }
    public class AjouterAdVM
    {
        [Display(Name = "Date de début")]
        [Required(ErrorMessage = "La date de début est requise.")]
        public DateTime DateDebut { get; set; }

        [Display(Name = "Date de fin")]
        [Required(ErrorMessage = "La date de fin est requise.")]
        public DateTime DateFin { get; set; }

        [Display(Name = "Budget")]
        [Required(ErrorMessage = "Le budget est requis.")]
        [Range(0, double.MaxValue, ErrorMessage = "Le budget doit être supérieur ou égal à zéro.")]
        public double Budget { get; set; }

        [Display(Name = "URL du contenu")]
        [Required(ErrorMessage = "L'URL du contenu est requise.")]
        [Url(ErrorMessage = "L'URL du contenu n'est pas valide.")]
        public string ContentUrl { get; set; }

        [Display(Name = "URL de l'annonce")]
        [Required(ErrorMessage = "L'URL de l'annonce est requise.")]
        [Url(ErrorMessage = "L'URL de l'annonce n'est pas valide.")]
        public string AdUrl { get; set; }

        [Display(Name = "Type d'annonce")]
        [Required(ErrorMessage = "Le type d'annonce est requis.")]
        public int IdType { get; set; }

        [Display(Name = "Éditeur")]
        [Required(ErrorMessage = "L'éditeur est requis.")]
        public int IdPublisher { get; set; }

        [Display(Name = "Tranche d'âge")]
        [Required(ErrorMessage = "La tranche d'âge est requise.")]
        public int IdAgeRange { get; set; }

        [Display(Name = "Localisation")]
        [Required(ErrorMessage = "La localisation est requise.")]
        public int IdLocation { get; set; }

        public List<SelectListItem>? ageRanges { get; set; } = null!;

        public List<SelectListItem>? locations  { get; set; } = null!;

        public List<SelectListItem>? publishers { get; set; } = null!;

        public List<SelectListItem>? types { get; set; } = null!;
        public List<O>? Os { get; set; } = null!;
        [Required(ErrorMessage = "Os is required.")]
        public List<int> oschoix { get; set; }
    }
}

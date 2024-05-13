using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModels.Abonnement
{
    public class AddAbonnementVM
    {
        [Display(Name = "Type Abonnement")]
        [Required(ErrorMessage = "Le champ Type d'Abonnement est requis.")]
        public string TypeAbonnement { get; set; }

        [Display(Name = "Date de Création")]
        [Required(ErrorMessage = "Le champ Date de Création est requis.")]
        public DateTime DateDeCreation { get; set; }

        [Required(ErrorMessage = "Le champ Solde est requis.")]
        [Range(0, double.MaxValue, ErrorMessage = "Le Solde doit être un nombre positif.")]
        public double Solde { get; set; }

        [Display(Name = "Nom d'étudiant")]
        [Required(ErrorMessage = "Le champ StudentId est requis.")]
        public int StudentId { get; set; }

        [Display(Name = "Lignes Sélectionnées")]
        public List<int> SelectedLineIds { get; set; } = new List<int>();

        public List<int> SelectedLineNums { get; set; } = new List<int>();

        public ICollection<AbonnementLigne> ListAbonnementLignes { get; set; } = new List<AbonnementLigne>();
    }
}

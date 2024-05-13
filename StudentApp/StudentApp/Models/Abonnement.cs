using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class Abonnement
{
    public int IdAbonnement { get; set; }

    public string TypeAbonnement { get; set; } = null!;

    public DateTime DateDeCreation { get; set; }

    public double Solde { get; set; }

    public int StudentId { get; set; }

    public virtual ICollection<AbonnementLigne> AbonnementLignes { get; set; } = new List<AbonnementLigne>();

    public virtual Student Student { get; set; } 

}

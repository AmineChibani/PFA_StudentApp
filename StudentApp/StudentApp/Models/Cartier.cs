using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class Cartier
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<BorderCartier> BorderCartiers { get; set; } = new List<BorderCartier>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<PointDeRecherche> PointDeRecherches { get; set; } = new List<PointDeRecherche>();
}

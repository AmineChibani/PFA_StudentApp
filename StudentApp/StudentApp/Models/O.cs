using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class O
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<CampainO> CampainOs { get; set; } = new List<CampainO>();
}

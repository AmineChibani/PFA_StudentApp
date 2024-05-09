using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class AdType
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();
}

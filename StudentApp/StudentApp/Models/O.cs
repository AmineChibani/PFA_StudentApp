using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class O
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Campaign> IdCampaigns { get; set; } = new List<Campaign>();
}

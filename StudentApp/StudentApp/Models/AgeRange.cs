using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class AgeRange
{
    public int Id { get; set; }

    public int Min { get; set; }

    public int Max { get; set; }

    public virtual ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();
}

using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class Publisher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public virtual ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();
}

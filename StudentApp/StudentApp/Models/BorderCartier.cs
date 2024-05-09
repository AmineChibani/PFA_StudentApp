using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class BorderCartier
{
    public int Id { get; set; }

    public double Lattitude { get; set; }

    public double Longitude { get; set; }

    public int IdCartier { get; set; }

    public virtual Cartier IdCartierNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class Historique
{
    public int IdHistorique { get; set; }

    public DateTime HeureMonter { get; set; }

    public int StudentId { get; set; }

    public int BusId { get; set; }

    public virtual Student Student { get; set; } = null!;
}

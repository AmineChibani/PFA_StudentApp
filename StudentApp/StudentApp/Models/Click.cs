using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class Click
{
    public int Id { get; set; }

    public int IdEtudient { get; set; }

    public int IdCampain { get; set; }

    public DateTime DateClick { get; set; }

    public string Os { get; set; } = null!;

    public virtual Campaign IdCampainNavigation { get; set; } = null!;

    public virtual Student IdEtudientNavigation { get; set; } = null!;
}

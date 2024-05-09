using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class AbonnementLigne
{
    public int IdAbnLigne { get; set; }

    public int AbonnementId { get; set; }

    public int LigneId { get; set; }

    public int NumLine { get; set; }

    public virtual Abonnement Abonnement { get; set; } = null!;
}

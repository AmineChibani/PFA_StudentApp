using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class CampainO
{
    public int IdOs { get; set; }

    public int IdCampaign { get; set; }

    public int Id { get; set; }

    public virtual Campaign IdCampaignNavigation { get; set; } = null!;

    public virtual O IdOsNavigation { get; set; } = null!;
}

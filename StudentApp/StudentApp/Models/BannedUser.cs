using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class BannedUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Reason { get; set; }

    public DateTime BannedAt { get; set; }

    public virtual Aiuser User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class Aiuser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AudioDatum> AudioData { get; set; } = new List<AudioDatum>();

    public virtual ICollection<BannedUser> BannedUsers { get; set; } = new List<BannedUser>();
}

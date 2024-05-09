using System;
using System.Collections.Generic;

namespace StudentApp.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}

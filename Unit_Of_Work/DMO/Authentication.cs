using System;
using System.Collections.Generic;

namespace Unit_Of_Work.DMO;

public partial class Authentication
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Autorization> Autorizations { get; set; } = new List<Autorization>();
}

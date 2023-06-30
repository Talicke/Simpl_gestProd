using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Ville
{
    public int IdVille { get; set; }

    public string NomVille { get; set; } = null!;

    public virtual ICollection<CodePostal> CodePostals { get; set; } = new List<CodePostal>();

    public virtual ICollection<Adress> IdAdresses { get; set; } = new List<Adress>();
}

using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Caracteristique
{
    public int IdCarac { get; set; }

    public string NomCarac { get; set; } = null!;

    public bool EstDisponible { get; set; }

    public virtual ICollection<Option> Options { get; set; } = new List<Option>();
}

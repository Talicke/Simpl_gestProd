using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Droit
{
    public int IdDroit { get; set; }

    public string NomDroit { get; set; } = null!;

    public virtual ICollection<Compte> Comptes { get; set; } = new List<Compte>();
}

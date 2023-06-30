using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Remise
{
    public int IdRemise { get; set; }

    public string? CodeRemise { get; set; }

    public short? Réduction { get; set; }

    public string? EstValide { get; set; }

    public int? IdStock { get; set; }

    public virtual Stock? IdStockNavigation { get; set; }

    public virtual ICollection<Compte> IdComptes { get; set; } = new List<Compte>();
}

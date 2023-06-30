using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Option
{
    public int IdOption { get; set; }

    public string IntitulerOption { get; set; } = null!;

    public bool EstDisponible { get; set; }

    public int IdCarac { get; set; }

    public virtual Caracteristique IdCaracNavigation { get; set; } = null!;

    public virtual ICollection<Stock> IdStocks { get; set; } = new List<Stock>();
}

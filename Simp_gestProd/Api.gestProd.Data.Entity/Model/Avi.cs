using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Avi
{
    public int IdAvis { get; set; }

    public string MessageAvis { get; set; } = null!;

    public DateTime DateAvis { get; set; }

    public int? IdStock { get; set; }

    public int IdCompte { get; set; }

    public virtual Compte IdCompteNavigation { get; set; } = null!;

    public virtual Stock? IdStockNavigation { get; set; }
}

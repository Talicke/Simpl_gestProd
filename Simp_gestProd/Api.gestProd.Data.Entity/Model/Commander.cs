using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Commander
{
    public int IdStock { get; set; }

    public int IdCompte { get; set; }

    public int IdExpedition { get; set; }

    public int? QteCommander { get; set; }

    public virtual Compte IdCompteNavigation { get; set; } = null!;

    public virtual Expedition IdExpeditionNavigation { get; set; } = null!;

    public virtual Stock IdStockNavigation { get; set; } = null!;
}

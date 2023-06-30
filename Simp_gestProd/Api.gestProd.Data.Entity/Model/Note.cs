using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Note
{
    public int IdNote { get; set; }

    public short ValeurNote { get; set; }

    public int? IdStock { get; set; }

    public int? IdCompte { get; set; }

    public virtual Compte? IdCompteNavigation { get; set; }

    public virtual Stock? IdStockNavigation { get; set; }
}

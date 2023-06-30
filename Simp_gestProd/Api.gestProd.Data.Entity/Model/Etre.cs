using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Etre
{
    public int IdExpedition { get; set; }

    public int IdStatus { get; set; }

    public DateTime? DateAffectation { get; set; }

    public virtual Expedition IdExpeditionNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;
}

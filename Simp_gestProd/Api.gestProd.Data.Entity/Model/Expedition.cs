using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Expedition
{
    public int IdExpedition { get; set; }

    public string? AdresseExpedition { get; set; }

    public DateTime DateExpedition { get; set; }

    public int? IdAdresse { get; set; }

    public virtual ICollection<Commander> Commanders { get; set; } = new List<Commander>();

    public virtual ICollection<Etre> Etres { get; set; } = new List<Etre>();

    public virtual Adress? IdAdresseNavigation { get; set; }
}

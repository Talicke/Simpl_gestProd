using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Stock
{
    public int IdStock { get; set; }

    public int QteStock { get; set; }

    public int? IdProduit { get; set; }

    public int? IdPrix { get; set; }

    public virtual ICollection<Avi> Avis { get; set; } = new List<Avi>();

    public virtual ICollection<Commander> Commanders { get; set; } = new List<Commander>();

    public virtual Prix? IdPrixNavigation { get; set; }

    public virtual Produit? IdProduitNavigation { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<Remise> Remises { get; set; } = new List<Remise>();

    public virtual ICollection<Image> IdImages { get; set; } = new List<Image>();

    public virtual ICollection<Option> IdOptions { get; set; } = new List<Option>();
}

using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Category
{
    public int IdCategorie { get; set; }

    public string NomCategorie { get; set; } = null!;

    public string DescCategorie { get; set; } = null!;

    public virtual ICollection<Produit> IdProduits { get; set; } = new List<Produit>();

    public virtual ICollection<Promotion> IdPromotions { get; set; } = new List<Promotion>();
}

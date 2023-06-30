using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Produit
{
    public int IdProduit { get; set; }

    public string DescProduit { get; set; } = null!;

    public string NomProduit { get; set; } = null!;

    public bool EstDisponible { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<Category> IdCategories { get; set; } = new List<Category>();
}

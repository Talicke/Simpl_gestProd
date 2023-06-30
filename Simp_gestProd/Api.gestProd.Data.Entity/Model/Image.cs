using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Image
{
    public int IdImage { get; set; }

    public string UrlImage { get; set; } = null!;

    public virtual ICollection<Stock> IdStocks { get; set; } = new List<Stock>();
}

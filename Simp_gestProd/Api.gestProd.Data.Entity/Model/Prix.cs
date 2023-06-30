using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Prix
{
    public int IdPrix { get; set; }

    public decimal? MontantPrix { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}

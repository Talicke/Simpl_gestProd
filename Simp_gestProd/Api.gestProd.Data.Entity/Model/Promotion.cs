using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Promotion
{
    public int IdPromotion { get; set; }

    public DateTime DateDebutPromo { get; set; }

    public DateTime DateFinPromo { get; set; }

    public short? ReductionPromo { get; set; }

    public virtual ICollection<Category> IdCategories { get; set; } = new List<Category>();
}

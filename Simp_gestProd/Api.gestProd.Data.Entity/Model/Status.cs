using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Status
{
    public int IdStatus { get; set; }

    public string IntitulerStatus { get; set; } = null!;

    public virtual ICollection<Etre> Etres { get; set; } = new List<Etre>();
}

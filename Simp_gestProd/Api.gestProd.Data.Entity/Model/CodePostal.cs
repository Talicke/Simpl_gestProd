using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class CodePostal
{
    public int IdCp { get; set; }

    public int? NombreCp { get; set; }

    public int? IdVille { get; set; }

    public virtual Ville? IdVilleNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Compte
{
    public int IdCompte { get; set; }

    public string LoginCompte { get; set; } = null!;

    public string MdpCompte { get; set; } = null!;

    public string? NomCompte { get; set; }

    public string? PrenomCompte { get; set; }

    public int IdDroit { get; set; }

    public virtual ICollection<Adress> Adresses { get; set; } = new List<Adress>();

    public virtual ICollection<Avi> Avis { get; set; } = new List<Avi>();

    public virtual ICollection<Commander> Commanders { get; set; } = new List<Commander>();

    public virtual Droit IdDroitNavigation { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<Remise> IdRemises { get; set; } = new List<Remise>();
}

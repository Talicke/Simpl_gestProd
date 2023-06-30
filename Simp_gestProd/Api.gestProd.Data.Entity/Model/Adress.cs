using System;
using System.Collections.Generic;

namespace Api.gestProd.Data.Entity.Model;

public partial class Adress
{
    public int IdAdresse { get; set; }

    public int NuméroAdresse { get; set; }

    public string? VoieAdresse { get; set; }

    public int? IdCompte { get; set; }

    public virtual ICollection<Expedition> Expeditions { get; set; } = new List<Expedition>();

    public virtual Compte? IdCompteNavigation { get; set; }

    public virtual ICollection<Ville> IdVilles { get; set; } = new List<Ville>();
}

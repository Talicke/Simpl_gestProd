using Api.gestProd.Data.Context.Contract;
using Api.gestProd.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.gestProd.Data.Context
{
    public interface IGestProdDBContext : IDBContext
    {

        DbSet<Adress> Adresses { get; set; }

        DbSet<Avi> Avis { get; set; }

        DbSet<Caracteristique> Caracteristiques { get; set; }

        DbSet<Categoriser> Categorisers { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<CodePostal> CodePostals { get; set; }

        DbSet<Commander> Commanders { get; set; }

        DbSet<Compte> Comptes { get; set; }

        DbSet<Contenir> Contenirs { get; set; }

        DbSet<Droit> Droits { get; set; }

        DbSet<Etre> Etres { get; set; }

        DbSet<Expedition> Expeditions { get; set; }

        DbSet<Illustrer> Illustrers { get; set; }

        DbSet<Image> Images { get; set; }

        DbSet<Note> Notes { get; set; }

        DbSet<Option> Options { get; set; }

        DbSet<Prix> Prixes { get; set; }

        DbSet<Produit> Produits { get; set; }

        DbSet<Profiter> Profiters { get; set; }

        DbSet<Promotion> Promotions { get; set; }

        DbSet<Promouvoir> Promouvoirs { get; set; }

        DbSet<Remise> Remises { get; set; }

        DbSet<Situer> Situers { get; set; }

        DbSet<Status> Statuses { get; set; }

        DbSet<Stock> Stocks { get; set; }

        DbSet<Ville> Villes { get; set; }
    }
}

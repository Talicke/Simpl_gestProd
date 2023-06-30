using System;
using System.Collections.Generic;
using Api.gestProd.Data.Context;
using Api.gestProd.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.gestProd.Data.Entity;

public partial class GestProdDBContext : DbContext , IGestProdDBContext
{
    public GestProdDBContext()
    {
    }

    public GestProdDBContext(DbContextOptions<GestProdDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<Avi> Avis { get; set; }

    public virtual DbSet<Caracteristique> Caracteristiques { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CodePostal> CodePostals { get; set; }

    public virtual DbSet<Commander> Commanders { get; set; }

    public virtual DbSet<Compte> Comptes { get; set; }

    public virtual DbSet<Droit> Droits { get; set; }

    public virtual DbSet<Etre> Etres { get; set; }

    public virtual DbSet<Expedition> Expeditions { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Prix> Prixes { get; set; }

    public virtual DbSet<Produit> Produits { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Remise> Remises { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Ville> Villes { get; set; }
    DbSet<Categoriser> IGestProdDBContext.Categorisers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    DbSet<Contenir> IGestProdDBContext.Contenirs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    DbSet<Illustrer> IGestProdDBContext.Illustrers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    DbSet<Profiter> IGestProdDBContext.Profiters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    DbSet<Promouvoir> IGestProdDBContext.Promouvoirs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    DbSet<Situer> IGestProdDBContext.Situers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Adress>(entity =>
        {
            entity.HasKey(e => e.IdAdresse).HasName("PRIMARY");

            entity.ToTable("adresses");

            entity.HasIndex(e => e.IdCompte, "id_compte");

            entity.Property(e => e.IdAdresse).HasColumnName("id_adresse");
            entity.Property(e => e.IdCompte).HasColumnName("id_compte");
            entity.Property(e => e.NuméroAdresse).HasColumnName("numéro_adresse");
            entity.Property(e => e.VoieAdresse)
                .HasMaxLength(100)
                .HasColumnName("voie_adresse");

            entity.HasOne(d => d.IdCompteNavigation).WithMany(p => p.Adresses)
                .HasForeignKey(d => d.IdCompte)
                .HasConstraintName("adresses_ibfk_1");

            entity.HasMany(d => d.IdVilles).WithMany(p => p.IdAdresses)
                .UsingEntity<Dictionary<string, object>>(
                    "Situer",
                    r => r.HasOne<Ville>().WithMany()
                        .HasForeignKey("IdVille")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("situer_ibfk_2"),
                    l => l.HasOne<Adress>().WithMany()
                        .HasForeignKey("IdAdresse")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("situer_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdAdresse", "IdVille")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("situer");
                        j.HasIndex(new[] { "IdVille" }, "id_ville");
                        j.IndexerProperty<int>("IdAdresse").HasColumnName("id_adresse");
                        j.IndexerProperty<int>("IdVille").HasColumnName("id_ville");
                    });
        });

        modelBuilder.Entity<Avi>(entity =>
        {
            entity.HasKey(e => e.IdAvis).HasName("PRIMARY");

            entity.ToTable("avis");

            entity.HasIndex(e => e.IdCompte, "id_compte");

            entity.HasIndex(e => e.IdStock, "id_stock");

            entity.Property(e => e.IdAvis).HasColumnName("id_avis");
            entity.Property(e => e.DateAvis)
                .HasColumnType("datetime")
                .HasColumnName("date_avis");
            entity.Property(e => e.IdCompte).HasColumnName("id_compte");
            entity.Property(e => e.IdStock).HasColumnName("id_stock");
            entity.Property(e => e.MessageAvis)
                .HasColumnType("text")
                .HasColumnName("message_avis");

            entity.HasOne(d => d.IdCompteNavigation).WithMany(p => p.Avis)
                .HasForeignKey(d => d.IdCompte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("avis_ibfk_2");

            entity.HasOne(d => d.IdStockNavigation).WithMany(p => p.Avis)
                .HasForeignKey(d => d.IdStock)
                .HasConstraintName("avis_ibfk_1");
        });

        modelBuilder.Entity<Caracteristique>(entity =>
        {
            entity.HasKey(e => e.IdCarac).HasName("PRIMARY");

            entity.ToTable("caracteristiques");

            entity.Property(e => e.IdCarac).HasColumnName("id_carac");
            entity.Property(e => e.EstDisponible).HasColumnName("estDisponible");
            entity.Property(e => e.NomCarac)
                .HasMaxLength(50)
                .HasColumnName("nom_carac");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.IdCategorie).HasColumnName("id_categorie");
            entity.Property(e => e.DescCategorie)
                .HasColumnType("text")
                .HasColumnName("desc_categorie");
            entity.Property(e => e.NomCategorie)
                .HasMaxLength(50)
                .HasColumnName("nom_categorie");

            entity.HasMany(d => d.IdPromotions).WithMany(p => p.IdCategories)
                .UsingEntity<Dictionary<string, object>>(
                    "Promouvoir",
                    r => r.HasOne<Promotion>().WithMany()
                        .HasForeignKey("IdPromotion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("promouvoir_ibfk_2"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("IdCategorie")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("promouvoir_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdCategorie", "IdPromotion")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("promouvoir");
                        j.HasIndex(new[] { "IdPromotion" }, "id_promotion");
                        j.IndexerProperty<int>("IdCategorie").HasColumnName("id_categorie");
                        j.IndexerProperty<int>("IdPromotion").HasColumnName("id_promotion");
                    });
        });

        modelBuilder.Entity<CodePostal>(entity =>
        {
            entity.HasKey(e => e.IdCp).HasName("PRIMARY");

            entity.ToTable("code_postal");

            entity.HasIndex(e => e.IdVille, "id_ville");

            entity.Property(e => e.IdCp).HasColumnName("id_cp");
            entity.Property(e => e.IdVille).HasColumnName("id_ville");
            entity.Property(e => e.NombreCp).HasColumnName("nombre_cp");

            entity.HasOne(d => d.IdVilleNavigation).WithMany(p => p.CodePostals)
                .HasForeignKey(d => d.IdVille)
                .HasConstraintName("code_postal_ibfk_1");
        });

        modelBuilder.Entity<Commander>(entity =>
        {
            entity.HasKey(e => new { e.IdStock, e.IdCompte, e.IdExpedition })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("commander");

            entity.HasIndex(e => e.IdCompte, "id_compte");

            entity.HasIndex(e => e.IdExpedition, "id_expedition");

            entity.Property(e => e.IdStock).HasColumnName("id_stock");
            entity.Property(e => e.IdCompte).HasColumnName("id_compte");
            entity.Property(e => e.IdExpedition).HasColumnName("id_expedition");
            entity.Property(e => e.QteCommander).HasColumnName("qte_commander");

            entity.HasOne(d => d.IdCompteNavigation).WithMany(p => p.Commanders)
                .HasForeignKey(d => d.IdCompte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("commander_ibfk_2");

            entity.HasOne(d => d.IdExpeditionNavigation).WithMany(p => p.Commanders)
                .HasForeignKey(d => d.IdExpedition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("commander_ibfk_3");

            entity.HasOne(d => d.IdStockNavigation).WithMany(p => p.Commanders)
                .HasForeignKey(d => d.IdStock)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("commander_ibfk_1");
        });

        modelBuilder.Entity<Compte>(entity =>
        {
            entity.HasKey(e => e.IdCompte).HasName("PRIMARY");

            entity.ToTable("comptes");

            entity.HasIndex(e => e.IdDroit, "id_droit");

            entity.Property(e => e.IdCompte).HasColumnName("id_compte");
            entity.Property(e => e.IdDroit).HasColumnName("id_droit");
            entity.Property(e => e.LoginCompte)
                .HasMaxLength(100)
                .HasColumnName("login_compte");
            entity.Property(e => e.MdpCompte)
                .HasMaxLength(100)
                .HasColumnName("mdp_compte");
            entity.Property(e => e.NomCompte)
                .HasMaxLength(50)
                .HasColumnName("nom_compte");
            entity.Property(e => e.PrenomCompte)
                .HasMaxLength(50)
                .HasColumnName("prenom_compte");

            entity.HasOne(d => d.IdDroitNavigation).WithMany(p => p.Comptes)
                .HasForeignKey(d => d.IdDroit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comptes_ibfk_1");
        });

        modelBuilder.Entity<Droit>(entity =>
        {
            entity.HasKey(e => e.IdDroit).HasName("PRIMARY");

            entity.ToTable("droits");

            entity.Property(e => e.IdDroit).HasColumnName("id_droit");
            entity.Property(e => e.NomDroit)
                .HasMaxLength(50)
                .HasColumnName("nom_droit");
        });

        modelBuilder.Entity<Etre>(entity =>
        {
            entity.HasKey(e => new { e.IdExpedition, e.IdStatus })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("etre");

            entity.HasIndex(e => e.IdStatus, "id_status");

            entity.Property(e => e.IdExpedition).HasColumnName("id_expedition");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.DateAffectation)
                .HasColumnType("datetime")
                .HasColumnName("date_affectation");

            entity.HasOne(d => d.IdExpeditionNavigation).WithMany(p => p.Etres)
                .HasForeignKey(d => d.IdExpedition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("etre_ibfk_1");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Etres)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("etre_ibfk_2");
        });

        modelBuilder.Entity<Expedition>(entity =>
        {
            entity.HasKey(e => e.IdExpedition).HasName("PRIMARY");

            entity.ToTable("expeditions");

            entity.HasIndex(e => e.IdAdresse, "id_adresse");

            entity.Property(e => e.IdExpedition).HasColumnName("id_expedition");
            entity.Property(e => e.AdresseExpedition)
                .HasMaxLength(255)
                .HasColumnName("adresse_expedition");
            entity.Property(e => e.DateExpedition)
                .HasColumnType("datetime")
                .HasColumnName("date_expedition");
            entity.Property(e => e.IdAdresse).HasColumnName("id_adresse");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Expeditions)
                .HasForeignKey(d => d.IdAdresse)
                .HasConstraintName("expeditions_ibfk_1");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.IdImage).HasName("PRIMARY");

            entity.ToTable("images");

            entity.Property(e => e.IdImage).HasColumnName("id_image");
            entity.Property(e => e.UrlImage)
                .HasMaxLength(255)
                .HasColumnName("url_image");

            entity.HasMany(d => d.IdStocks).WithMany(p => p.IdImages)
                .UsingEntity<Dictionary<string, object>>(
                    "Illustrer",
                    r => r.HasOne<Stock>().WithMany()
                        .HasForeignKey("IdStock")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("illustrer_ibfk_2"),
                    l => l.HasOne<Image>().WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("illustrer_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdImage", "IdStock")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("illustrer");
                        j.HasIndex(new[] { "IdStock" }, "id_stock");
                        j.IndexerProperty<int>("IdImage").HasColumnName("id_image");
                        j.IndexerProperty<int>("IdStock").HasColumnName("id_stock");
                    });
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.IdNote).HasName("PRIMARY");

            entity.ToTable("notes");

            entity.HasIndex(e => e.IdCompte, "id_compte");

            entity.HasIndex(e => e.IdStock, "id_stock");

            entity.Property(e => e.IdNote).HasColumnName("id_note");
            entity.Property(e => e.IdCompte).HasColumnName("id_compte");
            entity.Property(e => e.IdStock).HasColumnName("id_stock");
            entity.Property(e => e.ValeurNote).HasColumnName("valeur_note");

            entity.HasOne(d => d.IdCompteNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.IdCompte)
                .HasConstraintName("notes_ibfk_2");

            entity.HasOne(d => d.IdStockNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.IdStock)
                .HasConstraintName("notes_ibfk_1");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.IdOption).HasName("PRIMARY");

            entity.ToTable("options");

            entity.HasIndex(e => e.IdCarac, "id_carac");

            entity.Property(e => e.IdOption).HasColumnName("id_option");
            entity.Property(e => e.EstDisponible).HasColumnName("estDisponible");
            entity.Property(e => e.IdCarac).HasColumnName("id_carac");
            entity.Property(e => e.IntitulerOption)
                .HasMaxLength(50)
                .HasColumnName("intituler_option");

            entity.HasOne(d => d.IdCaracNavigation).WithMany(p => p.Options)
                .HasForeignKey(d => d.IdCarac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("options_ibfk_1");

            entity.HasMany(d => d.IdStocks).WithMany(p => p.IdOptions)
                .UsingEntity<Dictionary<string, object>>(
                    "Contenir",
                    r => r.HasOne<Stock>().WithMany()
                        .HasForeignKey("IdStock")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("contenir_ibfk_2"),
                    l => l.HasOne<Option>().WithMany()
                        .HasForeignKey("IdOption")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("contenir_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdOption", "IdStock")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("contenir");
                        j.HasIndex(new[] { "IdStock" }, "id_stock");
                        j.IndexerProperty<int>("IdOption").HasColumnName("id_option");
                        j.IndexerProperty<int>("IdStock").HasColumnName("id_stock");
                    });
        });

        modelBuilder.Entity<Prix>(entity =>
        {
            entity.HasKey(e => e.IdPrix).HasName("PRIMARY");

            entity.ToTable("prix");

            entity.Property(e => e.IdPrix).HasColumnName("id_prix");
            entity.Property(e => e.MontantPrix)
                .HasPrecision(15, 2)
                .HasColumnName("montant_prix");
        });

        modelBuilder.Entity<Produit>(entity =>
        {
            entity.HasKey(e => e.IdProduit).HasName("PRIMARY");

            entity.ToTable("produits");

            entity.Property(e => e.IdProduit).HasColumnName("id_produit");
            entity.Property(e => e.DescProduit)
                .HasColumnType("text")
                .HasColumnName("desc_produit");
            entity.Property(e => e.EstDisponible).HasColumnName("estDisponible");
            entity.Property(e => e.NomProduit)
                .HasMaxLength(50)
                .HasColumnName("nom_produit");

            entity.HasMany(d => d.IdCategories).WithMany(p => p.IdProduits)
                .UsingEntity<Dictionary<string, object>>(
                    "Categoriser",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("IdCategorie")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("categoriser_ibfk_2"),
                    l => l.HasOne<Produit>().WithMany()
                        .HasForeignKey("IdProduit")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("categoriser_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdProduit", "IdCategorie")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("categoriser");
                        j.HasIndex(new[] { "IdCategorie" }, "id_categorie");
                        j.IndexerProperty<int>("IdProduit").HasColumnName("id_produit");
                        j.IndexerProperty<int>("IdCategorie").HasColumnName("id_categorie");
                    });
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.IdPromotion).HasName("PRIMARY");

            entity.ToTable("promotions");

            entity.Property(e => e.IdPromotion).HasColumnName("id_promotion");
            entity.Property(e => e.DateDebutPromo)
                .HasColumnType("datetime")
                .HasColumnName("date_debut_promo");
            entity.Property(e => e.DateFinPromo)
                .HasColumnType("datetime")
                .HasColumnName("date_fin_promo");
            entity.Property(e => e.ReductionPromo).HasColumnName("reduction_promo");
        });

        modelBuilder.Entity<Remise>(entity =>
        {
            entity.HasKey(e => e.IdRemise).HasName("PRIMARY");

            entity.ToTable("remises");

            entity.HasIndex(e => e.IdStock, "id_stock");

            entity.Property(e => e.IdRemise).HasColumnName("id_remise");
            entity.Property(e => e.CodeRemise)
                .HasMaxLength(10)
                .HasColumnName("code_remise");
            entity.Property(e => e.EstValide)
                .HasMaxLength(50)
                .HasColumnName("estValide");
            entity.Property(e => e.IdStock).HasColumnName("id_stock");
            entity.Property(e => e.Réduction).HasColumnName("réduction");

            entity.HasOne(d => d.IdStockNavigation).WithMany(p => p.Remises)
                .HasForeignKey(d => d.IdStock)
                .HasConstraintName("remises_ibfk_1");

            entity.HasMany(d => d.IdComptes).WithMany(p => p.IdRemises)
                .UsingEntity<Dictionary<string, object>>(
                    "Profiter",
                    r => r.HasOne<Compte>().WithMany()
                        .HasForeignKey("IdCompte")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("profiter_ibfk_2"),
                    l => l.HasOne<Remise>().WithMany()
                        .HasForeignKey("IdRemise")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("profiter_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdRemise", "IdCompte")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("profiter");
                        j.HasIndex(new[] { "IdCompte" }, "id_compte");
                        j.IndexerProperty<int>("IdRemise").HasColumnName("id_remise");
                        j.IndexerProperty<int>("IdCompte").HasColumnName("id_compte");
                    });
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IntitulerStatus)
                .HasMaxLength(50)
                .HasColumnName("intituler_status");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.IdStock).HasName("PRIMARY");

            entity.ToTable("stocks");

            entity.HasIndex(e => e.IdPrix, "id_prix");

            entity.HasIndex(e => e.IdProduit, "id_produit");

            entity.Property(e => e.IdStock).HasColumnName("id_stock");
            entity.Property(e => e.IdPrix).HasColumnName("id_prix");
            entity.Property(e => e.IdProduit).HasColumnName("id_produit");
            entity.Property(e => e.QteStock).HasColumnName("qte_stock");

            entity.HasOne(d => d.IdPrixNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.IdPrix)
                .HasConstraintName("stocks_ibfk_2");

            entity.HasOne(d => d.IdProduitNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.IdProduit)
                .HasConstraintName("stocks_ibfk_1");
        });

        modelBuilder.Entity<Ville>(entity =>
        {
            entity.HasKey(e => e.IdVille).HasName("PRIMARY");

            entity.ToTable("villes");

            entity.Property(e => e.IdVille).HasColumnName("id_ville");
            entity.Property(e => e.NomVille)
                .HasMaxLength(50)
                .HasColumnName("nom_ville");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

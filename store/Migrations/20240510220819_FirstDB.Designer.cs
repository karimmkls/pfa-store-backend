﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using store.Helper.Data;

#nullable disable

namespace store.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20240510220819_FirstDB")]
    partial class FirstDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("store.Models.Att_Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Valeur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("att_produits");
                });

            modelBuilder.Entity("store.Models.Att_Variante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Valeur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VarianteId")
                        .HasColumnType("int");

                    b.Property<string>("cle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VarianteId");

                    b.ToTable("att_variantes");
                });

            modelBuilder.Entity("store.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointsFidelite")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("store.Models.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCommande")
                        .HasColumnType("datetime2");

                    b.Property<string>("Etat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("store.Models.Favorit", b =>
                {
                    b.Property<int>("IdFavoris")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFavoris"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("IdFavoris");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("Favorits");
                });

            modelBuilder.Entity("store.Models.LigneCommande", b =>
                {
                    b.Property<int>("IdLigneCommande")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLigneCommande"), 1L, 1);

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<double>("ProduitUnitaire")
                        .HasColumnType("float");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<int>("VarianteId")
                        .HasColumnType("int");

                    b.HasKey("IdLigneCommande");

                    b.HasIndex("CommandeId");

                    b.HasIndex("VarianteId");

                    b.ToTable("ligneCommandes");
                });

            modelBuilder.Entity("store.Models.LignePanier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PanierId")
                        .HasColumnType("int");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<int>("VarianteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PanierId");

                    b.HasIndex("VarianteId")
                        .IsUnique();

                    b.ToTable("LignePanier");
                });

            modelBuilder.Entity("store.Models.Paiement", b =>
                {
                    b.Property<int>("IdPaiement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaiement"), 1L, 1);

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePaimenet")
                        .HasColumnType("datetime2");

                    b.Property<double>("Montant")
                        .HasColumnType("float");

                    b.Property<string>("modePaiement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPaiement");

                    b.HasIndex("CommandeId")
                        .IsUnique();

                    b.ToTable("Paiements");
                });

            modelBuilder.Entity("store.Models.Panier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("paniers");
                });

            modelBuilder.Entity("store.Models.PhotoProduit", b =>
                {
                    b.Property<int>("PhotoProduitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhotoProduitId"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhotoProduitId");

                    b.HasIndex("ProductId");

                    b.ToTable("photoProduits");
                });

            modelBuilder.Entity("store.Models.PhotoVariante", b =>
                {
                    b.Property<int>("IdPhoto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPhoto"), 1L, 1);

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VarianteId")
                        .HasColumnType("int");

                    b.HasKey("IdPhoto");

                    b.HasIndex("VarianteId");

                    b.ToTable("photoVariantes");
                });

            modelBuilder.Entity("store.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<int>("QteStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("store.Models.Reclamation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommandeId");

                    b.ToTable("Reclamations");
                });

            modelBuilder.Entity("store.Models.Retour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRetour")
                        .HasColumnType("datetime2");

                    b.Property<int>("LigneCommandeId")
                        .HasColumnType("int");

                    b.Property<string>("TypeRetour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LigneCommandeId");

                    b.ToTable("Retours");
                });

            modelBuilder.Entity("store.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Note")
                        .HasColumnType("int");

                    b.Property<int>("VarianteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("VarianteId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("store.Models.Variante", b =>
                {
                    b.Property<int>("IdVariante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVariante"), 1L, 1);

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int");

                    b.Property<int>("QteStock")
                        .HasColumnType("int");

                    b.HasKey("IdVariante");

                    b.HasIndex("ProduitId");

                    b.ToTable("Variante");
                });

            modelBuilder.Entity("store.Models.Att_Produit", b =>
                {
                    b.HasOne("store.Models.Product", "Produit")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("store.Models.Att_Variante", b =>
                {
                    b.HasOne("store.Models.Variante", "Variante")
                        .WithMany("AttVs")
                        .HasForeignKey("VarianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Variante");
                });

            modelBuilder.Entity("store.Models.Command", b =>
                {
                    b.HasOne("store.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("store.Models.Favorit", b =>
                {
                    b.HasOne("store.Models.Client", "Client")
                        .WithMany("Favorits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("store.Models.Product", "Produit")
                        .WithMany("Favorits")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("store.Models.LigneCommande", b =>
                {
                    b.HasOne("store.Models.Command", "Commande")
                        .WithMany("LCs")
                        .HasForeignKey("CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("store.Models.Variante", "Variante")
                        .WithMany("LCs")
                        .HasForeignKey("VarianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commande");

                    b.Navigation("Variante");
                });

            modelBuilder.Entity("store.Models.LignePanier", b =>
                {
                    b.HasOne("store.Models.Panier", "Panier")
                        .WithMany("LPs")
                        .HasForeignKey("PanierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("store.Models.Variante", "Variante")
                        .WithOne("LignesPanier")
                        .HasForeignKey("store.Models.LignePanier", "VarianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Panier");

                    b.Navigation("Variante");
                });

            modelBuilder.Entity("store.Models.Paiement", b =>
                {
                    b.HasOne("store.Models.Command", "commande")
                        .WithOne("paiement")
                        .HasForeignKey("store.Models.Paiement", "CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("commande");
                });

            modelBuilder.Entity("store.Models.Panier", b =>
                {
                    b.HasOne("store.Models.Client", "Client")
                        .WithOne("Panier")
                        .HasForeignKey("store.Models.Panier", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("store.Models.PhotoProduit", b =>
                {
                    b.HasOne("store.Models.Product", "Produit")
                        .WithMany("PPs")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("store.Models.PhotoVariante", b =>
                {
                    b.HasOne("store.Models.Variante", "Variante")
                        .WithMany("PVs")
                        .HasForeignKey("VarianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Variante");
                });

            modelBuilder.Entity("store.Models.Reclamation", b =>
                {
                    b.HasOne("store.Models.Command", "Commande")
                        .WithMany("Recs")
                        .HasForeignKey("CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commande");
                });

            modelBuilder.Entity("store.Models.Retour", b =>
                {
                    b.HasOne("store.Models.LigneCommande", "LigneCommande")
                        .WithMany("retours")
                        .HasForeignKey("LigneCommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LigneCommande");
                });

            modelBuilder.Entity("store.Models.Review", b =>
                {
                    b.HasOne("store.Models.Client", "Client")
                        .WithMany("Reviews")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("store.Models.Variante", "Variante")
                        .WithMany("Reviews")
                        .HasForeignKey("VarianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Variante");
                });

            modelBuilder.Entity("store.Models.Variante", b =>
                {
                    b.HasOne("store.Models.Product", "Produit")
                        .WithMany("Variantes")
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("store.Models.Client", b =>
                {
                    b.Navigation("Favorits");

                    b.Navigation("Panier")
                        .IsRequired();

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("store.Models.Command", b =>
                {
                    b.Navigation("LCs");

                    b.Navigation("Recs");

                    b.Navigation("paiement")
                        .IsRequired();
                });

            modelBuilder.Entity("store.Models.LigneCommande", b =>
                {
                    b.Navigation("retours");
                });

            modelBuilder.Entity("store.Models.Panier", b =>
                {
                    b.Navigation("LPs");
                });

            modelBuilder.Entity("store.Models.Product", b =>
                {
                    b.Navigation("Favorits");

                    b.Navigation("PPs");

                    b.Navigation("Variantes");
                });

            modelBuilder.Entity("store.Models.Variante", b =>
                {
                    b.Navigation("AttVs");

                    b.Navigation("LCs");

                    b.Navigation("LignesPanier")
                        .IsRequired();

                    b.Navigation("PVs");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
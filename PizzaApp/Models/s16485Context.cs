using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaApp.Models
{
    public partial class s16485Context : DbContext
    {
        public s16485Context()
        {
        }

        public s16485Context(DbContextOptions<s16485Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaCala> PizzaCala { get; set; }
        public virtual DbSet<PizzaCustom> PizzaCustom { get; set; }
        public virtual DbSet<PizzaMenu> PizzaMenu { get; set; }
        public virtual DbSet<RodzajCiasta> RodzajCiasta { get; set; }
        public virtual DbSet<Rozmiar> Rozmiar { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Sos> Sos { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16485;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdministrator)
                    .HasName("Administrator_pk");

                entity.Property(e => e.IdAdministrator)
                    .HasColumnName("idAdministrator")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("idPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdSos).HasColumnName("idSos");

                entity.Property(e => e.NazwaPizza)
                    .IsRequired()
                    .HasColumnName("nazwaPizza")
                    .HasMaxLength(32);

                entity.HasOne(d => d.IdSosNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.IdSos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Sos");
            });

            modelBuilder.Entity<PizzaCala>(entity =>
            {
                entity.HasKey(e => e.IdGotowaPizza)
                    .HasName("PizzaCala_pk");

                entity.Property(e => e.IdGotowaPizza)
                    .HasColumnName("idGotowaPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("money");

                entity.Property(e => e.IdPizza).HasColumnName("idPizza");

                entity.Property(e => e.IdRodzajuCiasta).HasColumnName("idRodzajuCiasta");

                entity.Property(e => e.IdRozmiar).HasColumnName("idRozmiar");

                entity.Property(e => e.IdSkladnik).HasColumnName("idSkladnik");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaCala)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaSkladnik_Pizza");

                entity.HasOne(d => d.IdRodzajuCiastaNavigation)
                    .WithMany(p => p.PizzaCala)
                    .HasForeignKey(d => d.IdRodzajuCiasta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GotowaPizza_RodzajCiasta");

                entity.HasOne(d => d.IdRozmiarNavigation)
                    .WithMany(p => p.PizzaCala)
                    .HasForeignKey(d => d.IdRozmiar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GotowaPizza_Rozmiar");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.PizzaCala)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ListaSkladnikow_Skladnik");
            });

            modelBuilder.Entity<PizzaCustom>(entity =>
            {
                entity.HasKey(e => new { e.IdSkladnik, e.IdGotowaPizza })
                    .HasName("PizzaCustom_pk");

                entity.Property(e => e.IdSkladnik).HasColumnName("idSkladnik");

                entity.Property(e => e.IdGotowaPizza).HasColumnName("idGotowaPizza");

                entity.Property(e => e.IdSos).HasColumnName("idSos");

                entity.HasOne(d => d.IdGotowaPizzaNavigation)
                    .WithMany(p => p.PizzaCustom)
                    .HasForeignKey(d => d.IdGotowaPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaWlasna_PizzaGotowa");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.PizzaCustom)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaWlasna_Skladnik");

                entity.HasOne(d => d.IdSosNavigation)
                    .WithMany(p => p.PizzaCustom)
                    .HasForeignKey(d => d.IdSos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaWlasna_Sos");
            });

            modelBuilder.Entity<PizzaMenu>(entity =>
            {
                entity.HasKey(e => new { e.IdSkladnik, e.IdPizza })
                    .HasName("PizzaMenu_pk");

                entity.Property(e => e.IdSkladnik).HasColumnName("idSkladnik");

                entity.Property(e => e.IdPizza).HasColumnName("idPizza");

                entity.Property(e => e.IdSos).HasColumnName("idSos");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaMenu)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaMenu_Pizza");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.PizzaMenu)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaMenu_Skladnik");

                entity.HasOne(d => d.IdSosNavigation)
                    .WithMany(p => p.PizzaMenu)
                    .HasForeignKey(d => d.IdSos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaMenu_Sos");
            });

            modelBuilder.Entity<RodzajCiasta>(entity =>
            {
                entity.HasKey(e => e.IdRodzajuCiasta)
                    .HasName("RodzajCiasta_pk");

                entity.Property(e => e.IdRodzajuCiasta)
                    .HasColumnName("idRodzajuCiasta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("money");

                entity.Property(e => e.RodzajCiasta1)
                    .IsRequired()
                    .HasColumnName("rodzajCiasta")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Rozmiar>(entity =>
            {
                entity.HasKey(e => e.IdRozmiar)
                    .HasName("Rozmiar_pk");

                entity.Property(e => e.IdRozmiar)
                    .HasColumnName("idRozmiar")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("money");

                entity.Property(e => e.Rozmiar1)
                    .IsRequired()
                    .HasColumnName("rozmiar")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik)
                    .HasColumnName("idSkladnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaSkladnik)
                    .HasColumnName("cenaSkladnik")
                    .HasColumnType("money");

                entity.Property(e => e.NazwaSkladnik)
                    .IsRequired()
                    .HasColumnName("nazwaSkladnik")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Sos>(entity =>
            {
                entity.HasKey(e => e.IdSos)
                    .HasName("Sos_pk");

                entity.Property(e => e.IdSos)
                    .HasColumnName("idSos")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("money");

                entity.Property(e => e.NazwaSos)
                    .IsRequired()
                    .HasColumnName("nazwaSos")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie)
                    .HasColumnName("idZamowienie")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasColumnName("adres")
                    .HasMaxLength(64);

                entity.Property(e => e.CenaTotal)
                    .HasColumnName("cenaTotal")
                    .HasColumnType("money");

                entity.Property(e => e.CzasDostawy)
                    .HasColumnName("czasDostawy")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataZamowienia)
                    .HasColumnName("dataZamowienia")
                    .HasColumnType("date");

                entity.Property(e => e.IdGotowaPizza).HasColumnName("idGotowaPizza");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(32);

                entity.Property(e => e.NrTelefonu).HasColumnName("nrTelefonu");

                entity.HasOne(d => d.IdGotowaPizzaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdGotowaPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_GotowaPizza");
            });
        }
    }
}

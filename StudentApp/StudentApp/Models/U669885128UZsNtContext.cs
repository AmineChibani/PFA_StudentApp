using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace StudentApp.Models;

public partial class U669885128UZsNtContext : DbContext
{
    public U669885128UZsNtContext()
    {
    }

    public U669885128UZsNtContext(DbContextOptions<U669885128UZsNtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonnement> Abonnements { get; set; }

    public virtual DbSet<AbonnementLigne> AbonnementLignes { get; set; }

    public virtual DbSet<AdType> AdTypes { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AgeRange> AgeRanges { get; set; }

    public virtual DbSet<Aiuser> Aiusers { get; set; }

    public virtual DbSet<AudioDatum> AudioData { get; set; }

    public virtual DbSet<BannedUser> BannedUsers { get; set; }

    public virtual DbSet<BorderCartier> BorderCartiers { get; set; }

    public virtual DbSet<Campaign> Campaigns { get; set; }

    public virtual DbSet<Cartier> Cartiers { get; set; }

    public virtual DbSet<Click> Clicks { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<Historique> Historiques { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<O> Os { get; set; }

    public virtual DbSet<Pc> Pcs { get; set; }

    public virtual DbSet<PointDeRecherche> PointDeRecherches { get; set; }

    public virtual DbSet<Ps4> Ps4s { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<_1> _1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=212.1.209.223;port=3306;database=u669885128_uZsNT;user id=u669885128_Deb9t;password=Loulouta159", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.7-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Abonnement>(entity =>
        {
            entity.HasKey(e => e.IdAbonnement).HasName("PRIMARY");

            entity.ToTable("abonnement");

            entity.HasIndex(e => e.StudentId, "student_Id");

            entity.Property(e => e.IdAbonnement)
                .HasColumnType("int(11)")
                .HasColumnName("Id_abonnement");
            entity.Property(e => e.DateDeCreation)
                .HasColumnType("datetime")
                .HasColumnName("Date_de_creation");
            entity.Property(e => e.StudentId)
                .HasColumnType("int(11)")
                .HasColumnName("Student_Id");
            entity.Property(e => e.TypeAbonnement)
                .HasMaxLength(255)
                .HasColumnName("Type_abonnement");

            entity.HasOne(d => d.Student).WithMany(p => p.Abonnements)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("abonnement_ibfk_1");
        });

        modelBuilder.Entity<AbonnementLigne>(entity =>
        {
            entity.HasKey(e => e.IdAbnLigne).HasName("PRIMARY");

            entity.ToTable("abonnement/ligne");

            entity.HasIndex(e => e.AbonnementId, "abonnement_id");

            entity.Property(e => e.IdAbnLigne)
                .HasColumnType("int(11)")
                .HasColumnName("Id_abn_ligne");
            entity.Property(e => e.AbonnementId)
                .HasColumnType("int(11)")
                .HasColumnName("Abonnement_id");
            entity.Property(e => e.LigneId)
                .HasColumnType("int(11)")
                .HasColumnName("Ligne_id");
            entity.Property(e => e.NumLine)
                .HasColumnType("int(11)")
                .HasColumnName("Num_Line");

            entity.HasOne(d => d.Abonnement).WithMany(p => p.AbonnementLignes)
                .HasForeignKey(d => d.AbonnementId)
                .HasConstraintName("abonnement/ligne_ibfk_2");
        });

        modelBuilder.Entity<AdType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ad_type");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(30)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Admin");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(30)
                .HasColumnName("nom");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Prenom)
                .HasMaxLength(30)
                .HasColumnName("prenom");
        });

        modelBuilder.Entity<AgeRange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Age_Range");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Max)
                .HasColumnType("int(11)")
                .HasColumnName("max");
            entity.Property(e => e.Min)
                .HasColumnType("int(11)")
                .HasColumnName("min");
        });

        modelBuilder.Entity<Aiuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("AIusers")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<AudioDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("audio_data")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.AiuserId, "fk_AIuserId");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AiuserId)
                .HasColumnType("int(11)")
                .HasColumnName("AIuserId");
            entity.Property(e => e.Audio)
                .HasColumnType("blob")
                .HasColumnName("audio");
            entity.Property(e => e.Text)
                .HasMaxLength(255)
                .HasColumnName("text");

            entity.HasOne(d => d.Aiuser).WithMany(p => p.AudioData)
                .HasForeignKey(d => d.AiuserId)
                .HasConstraintName("fk_AIuserId");
        });

        modelBuilder.Entity<BannedUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BannedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("banned_at");
            entity.Property(e => e.Reason)
                .HasMaxLength(500)
                .HasColumnName("reason");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.BannedUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BannedUsers_ibfk_1");
        });

        modelBuilder.Entity<BorderCartier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("border_cartier");

            entity.HasIndex(e => e.IdCartier, "id_cartier");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdCartier)
                .HasColumnType("int(11)")
                .HasColumnName("id_cartier");
            entity.Property(e => e.Lattitude).HasColumnName("lattitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");

            entity.HasOne(d => d.IdCartierNavigation).WithMany(p => p.BorderCartiers)
                .HasForeignKey(d => d.IdCartier)
                .HasConstraintName("border_cartier_ibfk_1");
        });

        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Campaign");

            entity.HasIndex(e => e.IdAgeRange, "id_age_range");

            entity.HasIndex(e => e.IdLocation, "id_location");

            entity.HasIndex(e => e.IdPublisher, "id_publisher");

            entity.HasIndex(e => e.IdType, "id_type");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AdUrl)
                .HasMaxLength(200)
                .HasColumnName("ad_url");
            entity.Property(e => e.Budget).HasColumnName("budget");
            entity.Property(e => e.ContentUrl)
                .HasMaxLength(200)
                .HasColumnName("content_url");
            entity.Property(e => e.DateDebut)
                .HasColumnType("datetime")
                .HasColumnName("date_debut");
            entity.Property(e => e.DateFin)
                .HasColumnType("datetime")
                .HasColumnName("date_fin");
            entity.Property(e => e.IdAgeRange)
                .HasColumnType("int(11)")
                .HasColumnName("id_age_range");
            entity.Property(e => e.IdLocation)
                .HasColumnType("int(11)")
                .HasColumnName("id_location");
            entity.Property(e => e.IdPublisher)
                .HasColumnType("int(11)")
                .HasColumnName("id_publisher");
            entity.Property(e => e.IdType)
                .HasColumnType("int(11)")
                .HasColumnName("id_type");

            entity.HasOne(d => d.IdAgeRangeNavigation).WithMany(p => p.Campaigns)
                .HasForeignKey(d => d.IdAgeRange)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Campaign_ibfk_2");

            entity.HasOne(d => d.IdLocationNavigation).WithMany(p => p.Campaigns)
                .HasForeignKey(d => d.IdLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Campaign_ibfk_3");

            entity.HasOne(d => d.IdPublisherNavigation).WithMany(p => p.Campaigns)
                .HasForeignKey(d => d.IdPublisher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Campaign_ibfk_4");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Campaigns)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Campaign_ibfk_1");
        });

        modelBuilder.Entity<Cartier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cartier");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(100)
                .HasColumnName("libelle");

            entity.HasMany(d => d.PointDeRecherches).WithMany(p => p.IdCartiers)
                .UsingEntity<Dictionary<string, object>>(
                    "PointCartier",
                    r => r.HasOne<PointDeRecherche>().WithMany()
                        .HasForeignKey("PointDeRecherche")
                        .HasConstraintName("point_cartier_ibfk_2"),
                    l => l.HasOne<Cartier>().WithMany()
                        .HasForeignKey("IdCartier")
                        .HasConstraintName("point_cartier_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdCartier", "PointDeRecherche")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("point_cartier");
                        j.HasIndex(new[] { "IdCartier" }, "id_cartier");
                        j.HasIndex(new[] { "PointDeRecherche" }, "point_de_recherche");
                        j.IndexerProperty<int>("IdCartier")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_cartier");
                        j.IndexerProperty<int>("PointDeRecherche")
                            .HasColumnType("int(11)")
                            .HasColumnName("point_de_recherche");
                    });
        });

        modelBuilder.Entity<Click>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Click");

            entity.HasIndex(e => e.IdCampain, "id_campain");

            entity.HasIndex(e => e.IdEtudient, "id_etudient");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DateClick)
                .HasColumnType("datetime")
                .HasColumnName("date_click");
            entity.Property(e => e.IdCampain)
                .HasColumnType("int(11)")
                .HasColumnName("id_campain");
            entity.Property(e => e.IdEtudient)
                .HasColumnType("int(11)")
                .HasColumnName("id_etudient");
            entity.Property(e => e.Os)
                .HasMaxLength(30)
                .HasColumnName("os");

            entity.HasOne(d => d.IdCampainNavigation).WithMany(p => p.Clicks)
                .HasForeignKey(d => d.IdCampain)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Click_ibfk_1");

            entity.HasOne(d => d.IdEtudientNavigation).WithMany(p => p.Clicks)
                .HasForeignKey(d => d.IdEtudient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Click_ibfk_2");
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Historique>(entity =>
        {
            entity.HasKey(e => e.IdHistorique).HasName("PRIMARY");

            entity.ToTable("historique");

            entity.HasIndex(e => e.StudentId, "Student_id");

            entity.Property(e => e.IdHistorique)
                .HasColumnType("int(11)")
                .HasColumnName("Id_historique");
            entity.Property(e => e.BusId)
                .HasColumnType("int(11)")
                .HasColumnName("Bus_id");
            entity.Property(e => e.HeureMonter)
                .HasColumnType("datetime")
                .HasColumnName("Heure_monter");
            entity.Property(e => e.StudentId)
                .HasColumnType("int(11)")
                .HasColumnName("Student_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Historiques)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("historique_ibfk_1");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Location");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(30)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<O>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("OS");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(30)
                .HasColumnName("libelle");

            entity.HasMany(d => d.IdCampaigns).WithMany(p => p.IdOs)
                .UsingEntity<Dictionary<string, object>>(
                    "CampainO",
                    r => r.HasOne<Campaign>().WithMany()
                        .HasForeignKey("IdCampaign")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Campain_OS_ibfk_1"),
                    l => l.HasOne<O>().WithMany()
                        .HasForeignKey("IdOs")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Campain_OS_ibfk_2"),
                    j =>
                    {
                        j.HasKey("IdOs", "IdCampaign")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("Campain_OS");
                        j.HasIndex(new[] { "IdCampaign" }, "id_Campaign");
                        j.IndexerProperty<int>("IdOs")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_OS");
                        j.IndexerProperty<int>("IdCampaign")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_Campaign");
                    });
        });

        modelBuilder.Entity<Pc>(entity =>
        {
            entity.HasKey(e => e.PcId).HasName("PRIMARY");

            entity.ToTable("pcs");

            entity.Property(e => e.PcId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("pc_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.Price)
                .HasColumnType("int(100)")
                .HasColumnName("price");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'available'")
                .HasColumnType("enum('available','in_use','out_use')")
                .HasColumnName("status");
        });

        modelBuilder.Entity<PointDeRecherche>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("point_de_recherche");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Lattitude).HasColumnName("lattitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Neighborhood)
                .HasMaxLength(100)
                .HasColumnName("neighborhood");
        });

        modelBuilder.Entity<Ps4>(entity =>
        {
            entity.HasKey(e => e.Ps4Id).HasName("PRIMARY");

            entity.ToTable("ps4s");

            entity.Property(e => e.Ps4Id)
                .HasColumnType("int(11)")
                .HasColumnName("ps4_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.Price)
                .HasColumnType("int(100)")
                .HasColumnName("price");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'available'")
                .HasColumnType("enum('available','in_use','out_use')")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Contact)
                .HasMaxLength(30)
                .HasColumnName("contact");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdStudent).HasName("PRIMARY");

            entity.ToTable("student");

            entity.HasIndex(e => e.Cartier, "cartier");

            entity.Property(e => e.IdStudent)
                .HasColumnType("int(11)")
                .HasColumnName("Id_student");
            entity.Property(e => e.Adresse).HasMaxLength(255);
            entity.Property(e => e.Cartier)
                .HasColumnType("int(11)")
                .HasColumnName("cartier");
            entity.Property(e => e.Cen).HasMaxLength(255);
            entity.Property(e => e.Cin).HasMaxLength(255);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Nom).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Prenom).HasMaxLength(255);
            entity.Property(e => e.Tel).HasMaxLength(10);

            entity.HasOne(d => d.CartierNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Cartier)
                .HasConstraintName("student_ibfk_1");
        });

        modelBuilder.Entity<_1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("1");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Text)
                .HasMaxLength(100)
                .HasColumnName("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace desarrollo_web2.Data;

public partial class TurismoDbContext : DbContext
{
    public TurismoDbContext()
    {
    }

    public TurismoDbContext(DbContextOptions<TurismoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividades> Actividades { get; set; }

    public virtual DbSet<Empresas> Empresas { get; set; }

    public virtual DbSet<Historial> Historial { get; set; }

    public virtual DbSet<Informes> Informes { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    public virtual DbSet<Reseñas> Reseñas { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Laptop-Alexis-Jhair;Database=TurismoDB;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividades>(entity =>
        {
            entity.HasKey(e => e.ActividadId).HasName("PK__Activida__981483903C8E0DA9");

            entity.HasIndex(e => e.Title, "IDX_Actividades_Titulo");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Actividades)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Actividad__Empre__3D5E1FD2");
        });

        modelBuilder.Entity<Empresas>(entity =>
        {
            entity.HasKey(e => e.EmpresaId).HasName("PK__Empresas__7B9F2116B50A142F");

            entity.HasIndex(e => e.Email, "IDX_Empresas_Email");

            entity.HasIndex(e => e.Email, "UQ__Empresas__A9D105348DC43EAA").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Historial>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__9752068F090C20D3");

            entity.HasIndex(e => e.UserId, "IDX_Historial_UserId");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Actividad).WithMany(p => p.Historial)
                .HasForeignKey(d => d.ActividadId)
                .HasConstraintName("FK__Historial__Activ__49C3F6B7");

            entity.HasOne(d => d.User).WithMany(p => p.Historial)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Historial__UserI__48CFD27E");
        });

        modelBuilder.Entity<Informes>(entity =>
        {
            entity.HasKey(e => e.InformeId).HasName("PK__Informes__5B4587A663A1AD24");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PK__Reservas__C399376395B2CC4D");

            entity.HasIndex(e => e.UserId, "IDX_Reservas_UserId");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Actividad).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ActividadId)
                .HasConstraintName("FK__Reservas__Activi__45F365D3");

            entity.HasOne(d => d.User).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reservas__UserId__44FF419A");
        });

        modelBuilder.Entity<Reseñas>(entity =>
        {
            entity.HasKey(e => e.ReseñaId).HasName("PK__Reseñas__B17323A6BFE19371");

            entity.HasIndex(e => e.UserId, "IDX_Reseñas_UserId");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Actividad).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.ActividadId)
                .HasConstraintName("FK__Reseñas__Activid__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reseñas__UserId__403A8C7D");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Usuarios__1788CC4CE42878AA");

            entity.HasIndex(e => e.Email, "IDX_Usuarios_Email");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105340C3A9928").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

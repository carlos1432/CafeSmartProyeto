using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebCafeSmart.DataAccess;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cafe> Caves { get; set; }

    public virtual DbSet<CafeCaracteristica> CafeCaracteristicas { get; set; }

    public virtual DbSet<Caracteristica> Caracteristicas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=A-4PV8FG3\\SQLEXPRESS;Database=CafeSmart;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cafe>(entity =>
        {
            entity.HasKey(e => e.IdCafe).HasName("PK__Cafe__3B7BD254867905D1");

            entity.ToTable("Cafe");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCaracteristicaNavigation).WithMany(p => p.Caves)
                .HasForeignKey(d => d.IdCaracteristica)
                .HasConstraintName("FK__Cafe__IdCaracter__01D345B0");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Caves)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__Cafe__IdTipo__00DF2177");
        });

        modelBuilder.Entity<CafeCaracteristica>(entity =>
        {
            entity.HasKey(e => new { e.IdCafe, e.IdCaracteristica }).HasName("PK__Cafe_Car__E30DC3218EF6C346");

            entity.ToTable("Cafe_Caracteristica");

            entity.Property(e => e.PrecioAjuste)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCafeNavigation).WithMany(p => p.CafeCaracteristicas)
                .HasForeignKey(d => d.IdCafe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cafe_Cara__IdCaf__05A3D694");

            entity.HasOne(d => d.IdCaracteristicaNavigation).WithMany(p => p.CafeCaracteristicas)
                .HasForeignKey(d => d.IdCaracteristica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cafe_Cara__IdCar__0697FACD");
        });

        modelBuilder.Entity<Caracteristica>(entity =>
        {
            entity.HasKey(e => e.IdCaracteristica).HasName("PK__Caracter__8761175CA9E5B1C8");

            entity.ToTable("Caracteristica");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("Rol");

            entity.Property(e => e.DescripcionRol).HasMaxLength(50);
            entity.Property(e => e.NombreRol).HasMaxLength(20);
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.IdTipo);

            entity.ToTable("Tipo");

            entity.Property(e => e.Atributo).HasMaxLength(50);
            entity.Property(e => e.DescripcionTipo).HasMaxLength(500);
            entity.Property(e => e.NombreTipo).HasMaxLength(30);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.NroCedula).HasName("PK__Usuario__FBAA937C945A3226");

            entity.ToTable("Usuario");

            entity.Property(e => e.NroCedula).ValueGeneratedNever();
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombres).HasMaxLength(100);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__IdRol__756D6ECB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

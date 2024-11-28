using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sobremesa.Models;

namespace Sobremesa.Data;

public partial class SobremesaContext : DbContext
{
    public SobremesaContext()
    {
    }

    public SobremesaContext(DbContextOptions<SobremesaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alerta> Alertas { get; set; }

    public virtual DbSet<DetallesVenta> DetallesVenta { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Sobremesa;User Id=sa;Password=EDUARDOtrx1@;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alerta>(entity =>
        {
            entity.HasKey(e => e.AlertaId).HasName("PK__Alertas__D9EF47E5A2177F6F");

            entity.Property(e => e.AlertaId).HasColumnName("AlertaID");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InsumoId).HasColumnName("InsumoID");
            entity.Property(e => e.Mensaje).HasMaxLength(255);

            entity.HasOne(d => d.Insumo).WithMany(p => p.Alerta)
                .HasForeignKey(d => d.InsumoId)
                .HasConstraintName("FK__Alertas__InsumoI__5441852A");
        });

        modelBuilder.Entity<DetallesVenta>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__Detalles__6E19D6FADDCD9DF4");

            entity.Property(e => e.DetalleId).HasColumnName("DetalleID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VentaId).HasColumnName("VentaID");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetallesVenta)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("FK__DetallesV__Venta__5165187F");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.InsumoId).HasName("PK__Insumos__C10BE93677C07D81");

            entity.Property(e => e.InsumoId).HasColumnName("InsumoID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Usuarios__2B3DE7982301DC4F");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A195B3BD012").IsUnique();

            entity.Property(e => e.UsuarioID).HasColumnName("UsuarioID");
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__Ventas__5B41514CD0FE6DD8");

            entity.Property(e => e.VentaId).HasColumnName("VentaID");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

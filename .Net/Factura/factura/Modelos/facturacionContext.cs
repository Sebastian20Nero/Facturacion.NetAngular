using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace factura.Modelos
{
    public partial class facturacionContext : DbContext
    {
        public facturacionContext()
        {
        }

        public facturacionContext(DbContextOptions<facturacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Detalle> Detalles { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Enlazamos proyecto con bd
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQL"));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PK_cliente_1");

                entity.ToTable("cliente");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Fechanacimiento)
                    .HasMaxLength(10)
                    .HasColumnName("fechanacimiento")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Detalle>(entity =>
            {
                entity.HasKey(e => e.Numdetalle)
                    .HasName("PK_detalle_1");

                entity.ToTable("detalle");

                entity.Property(e => e.Numdetalle).HasColumnName("numdetalle");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecharegistro");

                entity.Property(e => e.Idfactura).HasColumnName("idfactura");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.HasOne(d => d.IdfacturaNavigation)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.Idfactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_factura");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_producto");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Idfactura)
                    .HasName("PK_factura_1");

                entity.ToTable("factura");

                entity.Property(e => e.Idfactura).HasColumnName("idfactura");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecharegistro");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Modopago)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modopago");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_factura_cliente");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PK_producto_1");

                entity.ToTable("producto");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio");

                entity.Property(e => e.Producto1)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("producto");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

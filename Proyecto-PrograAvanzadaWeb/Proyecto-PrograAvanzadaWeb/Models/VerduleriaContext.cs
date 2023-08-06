using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class VerduleriaContext : DbContext
    {
        public VerduleriaContext(DbContextOptions<VerduleriaContext> opciones)
            : base(opciones)
        {
        }

        public DbSet<usuario> usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<CarritoCompras> CarritosCompras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>(marca =>
            {
                marca.HasKey(x => x.IdMarca);
                marca.Property(x => x.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                marca.HasMany(m => m.ProductosDeMarca)
                    .WithOne(p => p.oMarca)
                    .HasForeignKey(p => p.IdMarca);
            });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.HasKey(x => x.IdCategoria);
                categoria.Property(x => x.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                categoria.HasMany(c => c.ProductosDeCategoria)
                    .WithOne(p => p.oCategoria)
                    .HasForeignKey(p => p.IdCategoria);
            });

            modelBuilder.Entity<Producto>(producto =>
            {
                producto.HasKey(x => x.IdProducto);
                producto.Property(x => x.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                producto.Property(x => x.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                producto.HasOne(x => x.oMarca)
                    .WithMany(m => m.ProductosDeMarca)
                    .HasForeignKey(x => x.IdMarca);

                producto.HasOne(x => x.oCategoria)
                    .WithMany(c => c.ProductosDeCategoria)
                    .HasForeignKey(x => x.IdCategoria);
            });
        }
    }
}

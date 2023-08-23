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
        public DbSet<CarritoCompras> CarritoCompras { get; set; }
        public DbSet<CarritoItem> CarritoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>(marca =>
            {
                marca.HasKey(x => x.IdMarca);
                marca.Property(x => x.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.HasKey(x => x.IdCategoria);
                categoria.Property(x => x.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
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

            });

            modelBuilder.Entity<Producto>()
                .HasOne(x => x.Marca)
                .WithMany(s => s.Producto)
                .HasForeignKey(f => f.IdMarca);
            modelBuilder.Entity<Producto>()
                .HasOne(u => u.Categoria)
                .WithMany(s => s.Producto)
                .HasForeignKey(f => f.IdCategoria);

            modelBuilder.Entity<CarritoCompras>(carrito =>
            {
                carrito.HasKey(x => x.IdCarrito);
                carrito.HasMany(c => c.CarritoItems)
                    .WithOne(ci => ci.CarritoCompras)
                    .HasForeignKey(ci => ci.IdCarrito);
            });

            modelBuilder.Entity<CarritoItem>(item =>
            {
                item.HasKey(x => x.IdCarritoItem);
                item.HasOne(ci => ci.CarritoCompras)
                    .WithMany(c => c.CarritoItems)
                    .HasForeignKey(ci => ci.IdCarrito);
                item.HasOne(ci => ci.Producto)
                    .WithMany() // Producto does not reference CarritoItems directly
                    .HasForeignKey(ci => ci.IdProducto);
            });
        }
    }
}

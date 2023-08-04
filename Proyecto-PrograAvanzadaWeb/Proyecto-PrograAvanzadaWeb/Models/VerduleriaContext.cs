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
            modelBuilder.Entity<Marca>(Marca =>
            {
                Marca.HasKey(x => x.IdMarca);
                Marca.Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Categoria>(Categoria =>
            {
                Categoria.HasKey(x => x.IdCategoria);
                Categoria.Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(Producto =>
            {
                Producto.HasKey(x => x.IdProducto);
                Producto.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
                Producto.Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            });



        }


    }
}

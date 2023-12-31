﻿using System.Collections.Generic;
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
        public DbSet<CarritoItem> CarritoItem { get; set; }

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

            modelBuilder.Entity<CarritoItem>(carritoitem =>
            {
                carritoitem.HasKey(ci => ci.IdCarritoItem);
                carritoitem.Property(ci => ci.Cantidad);
               

            });


            modelBuilder.Entity<Producto>()
                .HasOne(x => x.Marca)
                .WithMany(s => s.Producto)
                .HasForeignKey(f => f.IdMarca);
            modelBuilder.Entity<Producto>()
                .HasOne(u => u.Categoria)
                .WithMany(s => s.Producto)
                .HasForeignKey(f => f.IdCategoria);
  
            modelBuilder.Entity<CarritoItem>()
                .HasOne(ci => ci.Producto)
                .WithMany(s => s.CarritoItem)
                .HasForeignKey(ci => ci.IdProducto);
        }
    }
}
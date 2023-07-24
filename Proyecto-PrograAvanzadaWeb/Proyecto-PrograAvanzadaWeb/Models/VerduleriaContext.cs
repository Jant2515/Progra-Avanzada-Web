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
    }
}

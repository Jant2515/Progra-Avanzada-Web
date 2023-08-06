

using System.ComponentModel.DataAnnotations;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public Producto? Producto { get; set; }
    }
}

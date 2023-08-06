using System.ComponentModel.DataAnnotations;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class CarritoCompras
    {
        [Key]
        public int IdCarrito { get; set; }
        public List<Producto> Producto { get; set; }
        public List<usuario>? usuario { get; set; }
    }
}

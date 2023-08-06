using System.ComponentModel.DataAnnotations;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class CarritoCompras
    {
        [Key]
        public int IdCarrito { get; set; }
        public Producto oProducto { get; set; }
        public usuario oUsuario { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class CarritoItem
    {
        [Key]
        public int IdCarritoItem { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
    }
}

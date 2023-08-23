using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class CarritoCompras
    {
        [Key]
        public int IdCarrito { get; set; }

        public int IdUsuario { get; set; }
        public usuario usuario { get; set; }

        public List<CarritoItem> CarritoItems { get; set; }  // Lista de productos en el carrito con cantidades
    }

    public class CarritoItem
    {
        [Key]
        public int IdCarritoItem { get; set; }

        public int IdCarrito { get; set; }
        public CarritoCompras CarritoCompras { get; set; }

        public int IdProducto { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
    }
}

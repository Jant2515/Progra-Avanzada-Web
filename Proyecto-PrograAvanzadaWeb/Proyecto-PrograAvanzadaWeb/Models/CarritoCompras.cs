namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class CarritoCompras
    {
        public int IdCarrito { get; set; }
        public List<Producto> Producto { get; set; } = new List<Producto>();
    }
}

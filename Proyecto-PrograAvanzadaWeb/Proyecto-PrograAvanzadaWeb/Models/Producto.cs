using System.Text.RegularExpressions;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public bool Activo { get; set; }
        public List<Marca> Marca { get; set; }
        public List<Categoria> Categoria { get; set; }
    }
}

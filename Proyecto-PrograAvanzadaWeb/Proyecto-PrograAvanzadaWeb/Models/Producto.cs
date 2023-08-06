using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public bool Activo { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public Marca oMarca { get; set; }
        public Categoria oCategoria { get; set; }
    }
}

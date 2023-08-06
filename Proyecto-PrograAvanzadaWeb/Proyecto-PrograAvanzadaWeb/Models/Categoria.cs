

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        [InverseProperty("oCategoria")]
        public List<Producto> ProductosDeCategoria { get; set; }
    }
}

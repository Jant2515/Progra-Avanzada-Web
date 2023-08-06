using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        [InverseProperty("oMarca")]
        public List<Producto> ProductosDeMarca { get; set; }
    }
}

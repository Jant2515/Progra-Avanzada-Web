using System.ComponentModel.DataAnnotations;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public Producto? Producto { get; set; }
    }
}

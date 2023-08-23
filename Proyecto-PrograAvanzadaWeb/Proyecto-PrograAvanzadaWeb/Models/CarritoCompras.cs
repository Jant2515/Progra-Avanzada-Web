using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class CarritoCompras
    {
        [Key]
        public int IdCarrito { get; set; }

        [ForeignKey("usuario")]
        public int IdUsuario { get; set; }
        public usuario usuario { get; set; }

        public List<CarritoItem> CarritoItems { get; set; }
    }


}

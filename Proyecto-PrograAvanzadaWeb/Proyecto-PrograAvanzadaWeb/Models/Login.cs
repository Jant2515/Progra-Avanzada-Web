using System.ComponentModel.DataAnnotations;
namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Favor ingrese un Usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Favor ingrese una Contraseña")]
        public string Contraseña { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_PrograAvanzadaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly VerduleriaContext _context;

        public LoginController(VerduleriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] // Agregamos el atributo HttpPost para indicar que esta acción responde a peticiones POST
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Buscamos al usuario en la base de datos por correo y contraseña
                    var usuario = await _context.usuario.SingleOrDefaultAsync(x => x.Correo == login.Correo && x.Contrasena == login.Contraseña);

                    if (usuario != null)
                    {
                        // Ingresamos al sistema
                        HttpContext.Session.SetString("Correo", usuario.Correo);
                        HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(usuario));
                        return RedirectToAction("Index", "Home");
                    }
                }
                // Mensaje de error
                ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                return View("Index", login);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                ModelState.AddModelError(string.Empty, "Error en el inicio de sesión");
                return View("Index", login);
            }
        }
    }
}

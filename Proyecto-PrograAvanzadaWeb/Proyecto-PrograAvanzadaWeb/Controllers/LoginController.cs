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

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = await _context.usuario.SingleOrDefaultAsync(x => x.Correo == login.Correo && x.Contrasena == login.Contraseña);

                    if (usuario != null)
                    {
                        HttpContext.Session.SetString("Correo", usuario.Correo);
                        HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(usuario));

                        if (usuario.EsAdministrador)
                        {
                            return RedirectToAction("Create", "Producto");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }

                ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                return View("Index", login);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error en el inicio de sesión");
                return View("Index", login);
            }
        }

    }
}

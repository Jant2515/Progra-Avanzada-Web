using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proyecto_PrograAvanzadaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;

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

        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _context.usuario.Where(x => x.Correo == login.Usuario && x.Contrasena == login.Contraseña);
                    if (usuario.Any())
                    {
                        //Ingresamos al sistema
                        HttpContext.Session.SetString("Correo", usuario.FirstOrDefault().Correo);
                        HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(usuario.FirstOrDefault()));
                        return RedirectToAction("Index", "Home");
                    }
                    //Mensaje de error
                    return View("Index", login);
                }
                return View("Index", login);
            }
            catch (Exception ex)
            {
                return View("Index", login);
            }
        }
    }
}

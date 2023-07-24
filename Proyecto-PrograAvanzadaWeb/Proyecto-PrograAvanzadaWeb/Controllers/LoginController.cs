using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        // Acción para mostrar la vista de inicio de sesión
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Acción para realizar el inicio de sesión
        [HttpPost]
        public async Task<IActionResult> Login(string correo, string contrasena)
        {
            var usuario = await _context.usuario.SingleOrDefaultAsync(u => u.Correo == correo && u.Contrasena == contrasena && u.Activo);
            if (usuario != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombres),
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.EsAdministrador ? "Administrador" : "Usuario")
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            // Si el inicio de sesión falla, mostrar el mensaje de error
            ModelState.AddModelError("", "Credenciales inválidas o cuenta inactiva.");
            return View();
        }

        // Acción para cerrar sesión
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // Acción para mostrar la vista de registro
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Acción para realizar el registro
        [HttpPost]
        public async Task<IActionResult> Register(usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes agregar alguna lógica de validación adicional antes de guardar el usuario en la base de datos

                usuario.Activo = true;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            // Si hay errores en el modelo, mostrar el mensaje de error
            return View();
        }
    }
}

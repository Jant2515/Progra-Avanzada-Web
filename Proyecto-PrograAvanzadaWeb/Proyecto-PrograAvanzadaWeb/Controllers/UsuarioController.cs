using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;
using Proyecto_PrograAvanzadaWeb.Services;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly VerduleriaContext _context;
        private readonly IUsuarioService _usuario;

        public UsuarioController(VerduleriaContext context, IUsuarioService usuarios)
        {
            _context = context;
            _usuario = usuarios;
        }

        // Acción para mostrar la lista de usuarios
        public async Task<IActionResult> Index()
        {
            return View(_usuario.ObtenerUsuarios());
        }

        // Acción para mostrar el detalle de un usuario específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = _usuario.VerUsuarios(id.Value);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // Acción para mostrar la página de crear usuario
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Acción para procesar el formulario de crear usuario
        public IActionResult Create([Bind("IdUsuario,Nombres,Apellidos,Correo,Contrasena,EsAdministrador,Activo")] usuario usuarios)
        {
            if (ModelState.IsValid)
            {
                _usuario.AgregarUsuarios(usuarios);
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        // Acción para mostrar la página de editar usuario
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = _usuario.VerUsuarios(id.Value);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Nombres,Apellidos,Correo,Contrasena,EsAdministrador,Activo")] usuario usuarios)
        {
            if (id != usuarios.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _usuario.ModificarUsuarios(usuarios);
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        // Acción para mostrar la página de eliminar usuario
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = _usuario.VerUsuarios(id.Value);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // Acción para procesar la eliminación de un usuario
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _usuario.EliminarUsuarios(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return (_context.usuario?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}

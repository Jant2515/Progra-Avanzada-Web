using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly VerduleriaContext _context;

        public UsuarioController(VerduleriaContext context)
        {
            _context = context;
        }

        // Acción para mostrar la lista de usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.usuario.ToListAsync();
            return View(usuarios);
        }

        // Acción para mostrar el detalle de un usuario específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario.FirstOrDefaultAsync(u => u.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // Acción para mostrar la página de crear usuario
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // Acción para procesar el formulario de crear usuario
        public async Task<IActionResult> Create(usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // Acción para mostrar la página de editar usuario
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        // Acción para procesar el formulario de editar usuario
        public async Task<IActionResult> Edit(int id, usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // Acción para mostrar la página de eliminar usuario
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario.FirstOrDefaultAsync(u => u.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // Acción para procesar la eliminación de un usuario
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Método para verificar si un usuario existe
        private bool UsuarioExists(int id)
        {
            return _context.usuario.Any(u => u.IdUsuario == id);
        }
    }
}

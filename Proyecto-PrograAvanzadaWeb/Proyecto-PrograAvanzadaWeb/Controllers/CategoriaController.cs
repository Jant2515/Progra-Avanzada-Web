using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;
using Proyecto_PrograAvanzadaWeb.Services;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly VerduleriaContext _context;
        private readonly ICategoriaService _categoria;

        public CategoriaController(VerduleriaContext context, ICategoriaService categoria)
        {
            _context = context;
            _categoria = categoria;
        }

        public async Task<IActionResult> Index()
        {
            return View(_categoria.ObtenerCategorias());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _categoria.VerCategorias(id.Value);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Descripcion,Activo")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoria.AgregarCategorias(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _categoria.VerCategorias(id.Value);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,Descripcion,Activo")] Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _categoria.ModificarCategorias(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _categoria.VerCategorias(id.Value);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoria.EliminarCategorias(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriasExists(int id)
        {
            return (_context.Categoria?.Any(e => e.IdCategoria == id)).GetValueOrDefault();
        }
    }
}

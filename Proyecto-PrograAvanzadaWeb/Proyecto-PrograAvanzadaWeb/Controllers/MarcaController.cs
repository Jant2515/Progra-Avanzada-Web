using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;
using Proyecto_PrograAvanzadaWeb.Services;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class MarcaController : Controller
    {
        private readonly VerduleriaContext _context;
        private readonly IMarcaService _marca;

        public MarcaController(VerduleriaContext context, IMarcaService marca)
        {
            _context = context;
            _marca = marca;
        }

        public async Task<IActionResult> Index()
        {
            return View(_marca.ObtenerMarcas());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _marca.VerMarcas(id.Value);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Descripcion,Activo")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                _marca.AgregarMarcas(marca);
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _marca.VerMarcas(id.Value);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarca,Descripcion,Activo")] Marca marca)
        {
            if (id != marca.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _marca.ModificarMarcas(marca);
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _marca.VerMarcas(id.Value);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _marca.EliminarMarcas(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MarcasExists(int id)
        {
            return (_context.Marca?.Any(e => e.IdMarca == id)).GetValueOrDefault();
        }
    }
}

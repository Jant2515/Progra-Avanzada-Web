using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly VerduleriaContext _context;

        public CategoriaController(VerduleriaContext context)
        {
            _context = context;
        }

        // Acción para mostrar la lista de categorías
        public IActionResult Index()
        {
            var categorias = _context.Categoria.ToList();
            return View(categorias);
        }

        // Acción para mostrar el formulario de creación de categoría
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar la creación de categoría
        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // Acción para mostrar el formulario de edición de categoría
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categoria = _context.Categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // Acción para procesar la edición de categoría
        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // Acción para mostrar el formulario de eliminación de categoría
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var categoria = _context.Categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // Acción para procesar la eliminación de categoría
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var categoria = _context.Categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

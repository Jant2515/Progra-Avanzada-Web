using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class MarcaController : Controller
    {
        private readonly VerduleriaContext _context;

        public MarcaController(VerduleriaContext context)
        {
            _context = context;
        }

        // Acción para mostrar la lista de marcas
        public IActionResult Index()
        {
            var marcas = _context.Marca.ToList();
            return View(marcas);
        }

        // Acción para mostrar el formulario de creación de marca
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar la creación de marca
        [HttpPost]
        public IActionResult Create(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Marca.Add(marca);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // Acción para mostrar el formulario de edición de marca
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var marca = _context.Marca.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // Acción para procesar la edición de marca
        [HttpPost]
        public IActionResult Edit(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(marca).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // Acción para mostrar el formulario de eliminación de marca
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var marca = _context.Marca.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // Acción para procesar la eliminación de marca
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var marca = _context.Marca.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marca.Remove(marca);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

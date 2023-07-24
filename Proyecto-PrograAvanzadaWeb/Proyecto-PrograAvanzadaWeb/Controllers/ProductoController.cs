using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly VerduleriaContext _context;

        public ProductoController(VerduleriaContext context)
        {
            _context = context;
        }

        // Acción para mostrar la lista de productos
        public IActionResult Index()
        {
            var productos = _context.Producto.ToList();
            return View(productos);
        }

        // Acción para mostrar el formulario de creación de producto
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar la creación de producto
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Producto.Add(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // Acción para mostrar el formulario de edición de producto
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var producto = _context.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // Acción para procesar la edición de producto
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(producto).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // Acción para mostrar el formulario de eliminación de producto
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var producto = _context.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // Acción para procesar la eliminación de producto
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producto = _context.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

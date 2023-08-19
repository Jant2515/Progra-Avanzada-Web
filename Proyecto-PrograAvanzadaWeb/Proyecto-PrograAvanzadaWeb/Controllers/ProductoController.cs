using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;
using Proyecto_PrograAvanzadaWeb.Services;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly VerduleriaContext _context;
        private readonly IProductoService _producto;

        public ProductoController(VerduleriaContext context, IProductoService producto)
        {
            _context = context;
            _producto = producto;
        }

        public async Task<IActionResult> Index()
        {
            return View(_producto.ObtenerProductos());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _producto.VerProductos(id.Value);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        public IActionResult Create()
        {
            ViewData["DropMarcas"] = new SelectList(_context.Marca, "IdMarca", "Descripcion");
            ViewData["DropCategorias"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdProducto,Nombre,Descripcion,Precio,Stock,RutaImagen,Activo,IdMarca,IdCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _producto.AgregarProductos(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _producto.VerProductos(id.Value);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,Nombre,Descripcion,Precio,Stock,RutaImagen,Activo,Marca,Categoria")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _producto.ModificarProductos(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _producto.VerProductos(id.Value);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _producto.EliminarProductos(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return (_context.Producto?.Any(e => e.IdProducto == id)).GetValueOrDefault();
        }
    }
}

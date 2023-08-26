using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;
using System.Linq;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class CarritoComprasController : Controller
    {
        private readonly VerduleriaContext _context;

        public CarritoComprasController(VerduleriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var carritoItems = _context.CarritoItem
                .Include(ci => ci.Producto).ToList();
            ViewBag.Total = CalcularTotal(carritoItems);

            return View(carritoItems);
        }

        public IActionResult AgregarAlCarrito(int idProducto, int cantidad)
        {
            var producto = _context.Producto.Find(idProducto);

            if (producto == null)
            {
                return NotFound();
            }

            var carritoItem = new CarritoItem
            {
                Producto = producto,
                Cantidad = cantidad
            };

            _context.CarritoItem.Add(carritoItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EliminarDelCarrito(int idCarritoItem)
        {
            if (idCarritoItem <= 0)
            {
                // Manejar el caso de un idCarritoItem inválido
                return RedirectToAction(nameof(Index));
            }

            var carritoItem = _context.CarritoItem.SingleOrDefault(item => item.IdCarritoItem == idCarritoItem);

            if (carritoItem != null)
            {
                try
                {
                    _context.CarritoItem.Remove(carritoItem);
                    _context.SaveChanges();

                    // Agregar mensaje de confirmación a TempData
                    TempData["Mensaje"] = "El elemento se eliminó del carrito correctamente.";
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que ocurra
                    TempData["Error"] = "Ocurrió un error al eliminar el elemento del carrito.";
                }
            }
            else
            {
                TempData["Error"] = "El elemento no se encontró en el carrito.";
            }

            return RedirectToAction(nameof(Index));
        }


        private decimal CalcularTotal(IEnumerable<CarritoItem> carritoItems)
        {
            decimal total = 0;
            foreach (var item in carritoItems)
            {
                total += item.Producto.Precio * item.Cantidad;
            }
            return total;
        }
    }
}

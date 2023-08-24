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
            var carritoItem = _context.CarritoItem.Find(idCarritoItem);

            if (carritoItem != null)
            {
                _context.CarritoItem.Remove(carritoItem);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
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

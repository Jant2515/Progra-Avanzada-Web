
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class CarritoComprasController : Controller
    {

        private readonly VerduleriaContext _dbContext;

        public CarritoComprasController(VerduleriaContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        // Agregar productos al carrito
        public async Task<IActionResult> AgregarAlCarrito(int idProducto, int cantidad)
        {
            var usuarioId = ObtenerIdUsuarioActual();

            var carrito = await _dbContext.CarritosCompras
                .Include(c => c.CarritoItems)
                .FirstOrDefaultAsync(c => c.IdUsuario == usuarioId);

            var producto = await _dbContext.Producto.FindAsync(idProducto);

            if (carrito == null)
            {
                carrito = new CarritoCompras
                {
                    IdUsuario = usuarioId,
                    CarritoItems = new List<CarritoItem>()
                };
                _dbContext.CarritosCompras.Add(carrito);
            }

            var carritoItem = carrito.CarritoItems.FirstOrDefault(item => item.IdProducto == idProducto);

            if (carritoItem == null)
            {
                carritoItem = new CarritoItem
                {
                    IdProducto = idProducto,
                    Cantidad = cantidad
                };
                carrito.CarritoItems.Add(carritoItem);
            }
            else
            {
                carritoItem.Cantidad += cantidad;
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index"); // Redirigir a la vista del carrito
        }

        // Implementa métodos para eliminar y actualizar cantidades de productos en el carrito

        private int ObtenerIdUsuarioActual()
        {
            // Lógica para obtener el ID del usuario actual
            // Puedes usar la autenticación de .NET Core
            return 1; // Solo como ejemplo
        }
    
}
}

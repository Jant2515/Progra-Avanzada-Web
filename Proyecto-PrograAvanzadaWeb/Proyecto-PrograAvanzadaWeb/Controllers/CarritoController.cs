using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoComprasController : ControllerBase
    {
        private readonly VerduleriaContext _dbContext;

        public CarritoComprasController(VerduleriaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarritoCompras>>> GetCarritosCompras()
        {
            return await _dbContext.CarritosCompras.Include(c => c.Producto).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoCompras>> GetCarritoCompra(int id)
        {
            var carritoCompra = await _dbContext.CarritosCompras.Include(c => c.Producto).FirstOrDefaultAsync(c => c.Id == id);

            if (carritoCompra == null)
            {
                return NotFound();
            }

            return carritoCompra;
        }

        [HttpPost]
        public async Task<ActionResult<CarritoCompras>> PostCarritoCompra(CarritoCompras carritoCompra)
        {
            _dbContext.CarritosCompras.Add(carritoCompra);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetCarritoCompra", new { id = carritoCompra.Id }, carritoCompra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarritoCompra(int id, CarritoCompras carritoCompra)
        {
            if (id != carritoCompra.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(carritoCompra).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoCompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarritoCompra(int id)
        {
            var carritoCompra = await _dbContext.CarritosCompras.FindAsync(id);
            if (carritoCompra == null)
            {
                return NotFound();
            }

            _dbContext.CarritosCompras.Remove(carritoCompra);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool CarritoCompraExists(int id)
        {
            return _dbContext.CarritosCompras.Any(e => e.Id == id);
        }
    }
}   

    

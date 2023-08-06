using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Services
{
    public class ProductoService : IProductoService
    {
        private readonly VerduleriaContext _context;
        public ProductoService(VerduleriaContext context)
        {
            _context = context;
        }

        public bool AgregarProductos(Producto producto)
        {
            try
            {
                _context.Producto.Add(producto);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EliminarProductos(int id)
        {
            var producto = _context.Producto.Find(id);
            if (producto != null)
            {
                _context.Producto.Remove(producto);
                _context.SaveChanges();
            }
        }

        public bool ModificarProductos(Producto producto)
        {
            try
            {
                _context.Producto.Update(producto);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Producto> ObtenerProductos()
        {
            var ListaProductos = _context.Producto
                .Include(x => x.oMarca)
                .Include(y => y.oCategoria)
                .ToList();
            return ListaProductos;
        }


        public Producto VerProductos(int ID)
        {
            return _context.Producto.FirstOrDefault(x => x.IdProducto == ID);
        }
    }
}

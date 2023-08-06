using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly VerduleriaContext _context;
        public CategoriaService(VerduleriaContext context)
        {
            _context = context;
        }

        public bool AgregarCategorias(Categoria categoria)
        {
            try
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EliminarCategorias(int id)
        {
            var categoria = _context.Categoria.Find(id);
            if (categoria != null)
            {
                _context.Categoria.Remove(categoria);
                _context.SaveChanges();
            }
        }

        public bool ModificarCategorias(Categoria categoria)
        {
            try
            {
                _context.Categoria.Update(categoria);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Categoria> ObtenerCategorias()
        {
            var ListaCategorias = _context.Categoria.Include(x => x.Producto).ToList();
            return ListaCategorias;
        }


        public Categoria VerCategorias(int ID)
        {
            return _context.Categoria.FirstOrDefault(x => x.IdCategoria == ID);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly VerduleriaContext _context;
        public MarcaService(VerduleriaContext context)
        {
            _context = context;
        }

        public bool AgregarMarcas(Marca marca)
        {
            try
            {
                _context.Marca.Add(marca);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EliminarMarcas(int id)
        {
            var marca = _context.Marca.Find(id);
            if (marca != null)
            {
                _context.Marca.Remove(marca);
                _context.SaveChanges();
            }
        }

        public bool ModificarMarcas(Marca marca)
        {
            try
            {
                _context.Marca.Update(marca);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Marca> ObtenerMarcas()
        {
            var ListaMarcas = _context.Marca.Include(x => x.Producto).ToList();
            return ListaMarcas;
        }


        public Marca VerMarcas(int ID)
        {
            return _context.Marca.FirstOrDefault(x => x.IdMarca == ID);
        }
    }
}

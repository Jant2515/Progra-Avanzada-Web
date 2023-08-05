using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Services
{
    public interface ICategoriaService
    {
        List<Categoria> ObtenerCategorias();
        bool AgregarCategorias(Categoria categoria);
        bool ModificarCategorias(Categoria categoria);
        void EliminarCategorias(int id);
        Categoria VerCategorias(int ID);
    }
}

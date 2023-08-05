using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Services
{
    public interface IProductoService
    {
        List<Producto> ObtenerProductos();
        bool AgregarProductos(Producto producto);
        bool ModificarProductos(Producto producto);
        void EliminarProductos(int id);
        Producto VerProductos(int ID);
    }
}

using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Services
{
    public interface IMarcaService
    {
        List<Marca> ObtenerMarcas();
        bool AgregarMarcas(Marca marca);
        bool ModificarMarcas(Marca marca);
        void EliminarMarcas(int id);
        Marca VerMarcas(int ID);
    }
}

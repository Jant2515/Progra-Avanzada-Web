using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Services
{
    public interface IUsuarioService
    {
        List<usuario> ObtenerUsuarios();
        bool AgregarUsuarios(usuario usuarios);
        bool ModificarUsuarios(usuario usuarios);
        void EliminarUsuarios(int id);
        usuario VerUsuarios(int ID);
    }
}

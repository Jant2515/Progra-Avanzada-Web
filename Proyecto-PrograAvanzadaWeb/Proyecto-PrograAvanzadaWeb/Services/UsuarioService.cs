using Proyecto_PrograAvanzadaWeb.Models;

namespace Proyecto_PrograAvanzadaWeb.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly VerduleriaContext _context;
        public UsuarioService(VerduleriaContext context)
        {
            _context = context;
        }

        public bool AgregarUsuarios(usuario usuarios)
        {
            try
            {
                _context.usuario.Add(usuarios);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EliminarUsuarios(int id)
        {
            var usuarios = _context.usuario.Find(id);
            if (usuarios != null)
            {
                _context.usuario.Remove(usuarios);
                _context.SaveChanges();
            }
        }

        public bool ModificarUsuarios(usuario usuarios)
        {
            try
            {
                _context.usuario.Update(usuarios);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<usuario> ObtenerUsuarios()
        {
            var ListaUsuarios = _context.usuario.ToList();
            return ListaUsuarios;
        }


        public usuario VerUsuarios(int ID)
        {
            return _context.usuario.FirstOrDefault(x => x.IdUsuario == ID);
        }
    }
}

namespace Proyecto_PrograAvanzadaWeb.Services
{
    public class ScopedService : IScopedService
    {
        Guid id;
        public ScopedService()
        {
            id = Guid.NewGuid();
        }
        public Guid ObtenerID()
        {
            return id;
        }
    }
}

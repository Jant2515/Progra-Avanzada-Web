namespace Proyecto_PrograAvanzadaWeb.Services
{
    public class TransientService : ITransientService
    {
        Guid id;
        public TransientService()
        {
            id = Guid.NewGuid();
        }
        public Guid ObtenerID()
        {
            return id;
        }
    }
}

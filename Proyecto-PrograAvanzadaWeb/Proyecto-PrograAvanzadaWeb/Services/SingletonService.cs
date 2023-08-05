namespace Proyecto_PrograAvanzadaWeb.Services
{
    public class SingletonService : ISingletonService
    {
        Guid id;
        public SingletonService()
        {
            id = Guid.NewGuid();
        }
        public Guid ObtenerID()
        {
            return id;
        }
    }
}

namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int IdProducto { get; set; }
        public Producto? Producto { get; set; }
    }
}

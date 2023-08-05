﻿namespace Proyecto_PrograAvanzadaWeb.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int IdProducto { get; set; }
        public Producto? Producto { get; set; }
    }
}

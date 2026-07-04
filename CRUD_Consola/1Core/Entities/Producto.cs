namespace CRUD_Consola.Core.Entities
{
    internal class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }

        public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
    }
}

namespace CRUD_Consola.Core.Entities
{
    internal class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Contacto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();

        public override string ToString()
        {
            return $"{ProveedorId}, {Nombre}, {Contacto}, {Telefono}";
        }
    }
}

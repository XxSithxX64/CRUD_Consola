namespace CRUD_Consola.Core.Entities
{
    internal class Empleado : Persona
    {
        public string Cargo { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; }

        // Relación con pedidos registrados
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}

namespace CRUD_Consola.Core.Entities
{
    internal class Cliente : Persona
    {
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;

        // Relación con pedidos, facturas, etc.
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}

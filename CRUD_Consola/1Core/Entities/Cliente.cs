namespace CRUD_Consola.Core.Entities
{
    internal class Cliente : Persona
    {
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;

        // Relación con pedidos, facturas, etc.
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public override string ToString()
        {
            return $"{PersonaId}, {Nombres}, {ApellidoPat}, {ApellidoMat}, {DocIdentidad}, {FechaNacimiento}, {Email}, {Telefono}, {Direccion}, {FechaRegistro:dd/MM/yyyy}, {Activo}";
        }
    }
}

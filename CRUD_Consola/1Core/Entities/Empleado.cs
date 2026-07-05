namespace CRUD_Consola.Core.Entities
{
    public class Empleado : Persona
    {
        public string Cargo { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; }

        // Relación con pedidos registrados
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public override string ToString()
        {
            return $"{PersonaId} {Nombres} {ApellidoPat} {ApellidoMat} - " +
                   $"Cargo: {Cargo}, Contratado: {FechaContratacion:dd/MM/yyyy}, " +
                   $"DNI: {DocIdentidad}, Nac: {FechaNacimiento:dd/MM/yyyy}, " +
                   $"Email: {Email}, Tel: {Telefono}, Dir: {Direccion}";
        }
    }
}

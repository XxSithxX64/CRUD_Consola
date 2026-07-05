namespace CRUD_Consola.Core.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; }

        public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
        public Factura? Factura { get; set; }

        public override string ToString()
        {
            return $"PedidoId: {PedidoId}, Fecha: {Fecha}, ClienteId: {ClienteId}, EmpleadoId: {EmpleadoId}";
        }
    }
}

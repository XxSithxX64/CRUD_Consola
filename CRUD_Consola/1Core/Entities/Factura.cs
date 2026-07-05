namespace CRUD_Consola.Core.Entities
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        public DateTime FechaEmision { get; set; }
        public decimal MontoTotal { get; set; }

        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    }
}

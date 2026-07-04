using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Consola.Core.Entities
{
    internal class Factura
    {
        public int FacturaId { get; set; }
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        public DateTime FechaEmision { get; set; }
        public decimal MontoTotal { get; set; }

        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    }
}

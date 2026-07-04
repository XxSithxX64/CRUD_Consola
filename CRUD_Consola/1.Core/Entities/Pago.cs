using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Consola.Core.Entities
{
    internal class Pago
    {
        public int PagoId { get; set; }
        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }

        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
    }
}

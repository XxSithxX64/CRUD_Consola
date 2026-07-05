namespace CRUD_Consola.Core.Entities
{
    public class Pago
    {
        public int PagoId { get; set; }
        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }

        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"PagoId: {PagoId}, FacturaId: {FacturaId}, FechaPago: {FechaPago:dd/MM/yyyy}, " +
                   $"Monto: {Monto:C}, MetodoPago: {MetodoPago}";
        }
    }
}

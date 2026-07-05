using System.ComponentModel.DataAnnotations;

namespace CRUD_Consola.Core.Entities
{
    public class DetallePedido
    {
        [Key]
        public int DetalleId { get; set; }
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public override string ToString()
        {
            return $"DetalleId: {DetalleId}, PedidoId: {PedidoId}, ProductoId: {ProductoId}, " +
                   $"Cantidad: {Cantidad}, PrecioUnitario: {PrecioUnitario:C}";
        }
    }
}

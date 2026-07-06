
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IRepository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        IEnumerable<Pedido> GetPedidosConClienteYEmpleado();
        IEnumerable<Pedido> GetPedidosPorCliente(int clienteId);
        IEnumerable<Pedido> GetPedidosPorEmpleado(int empleadoId);
        IEnumerable<Pedido> GetPedidosPorSucursal(int sucursalId);
        IEnumerable<Pedido> GetPedidosPorFecha(DateTime inicio, DateTime fin);
        Pedido GetPedidoCompleto(int pedidoId);
        decimal CalcularTotalPedido(int pedidoId);
        bool VerificarStock(int pedidoId);
        void ActualizarStockDespuesDePedido(int pedidoId);
        IEnumerable<object> GetResumenVentasPorCategoria();
        Factura GenerarFacturaDesdePedido(int pedidoId);
    }
}

using CRUD_Consola._1Core.IRepository;
using CRUD_Consola._1Core.IService;
using CRUD_Consola._2Infrastructure.Repositories;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services
{
    public class PedidoService : Service<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository) : base(pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }
        public IEnumerable<Pedido> GetPedidosConClienteYEmpleado()
        {
            return pedidoRepository.GetPedidosConClienteYEmpleado();
        }
        // 🔹 Pedidos por cliente
        public IEnumerable<Pedido> GetPedidosPorCliente(int clienteId)
        {
            return pedidoRepository.GetPedidosPorCliente(clienteId);
        }

        // 🔹 Pedidos por empleado
        public IEnumerable<Pedido> GetPedidosPorEmpleado(int empleadoId)
        {
            return pedidoRepository.GetPedidosPorEmpleado(empleadoId);
        }

        // 🔹 Pedidos por sucursal
        public IEnumerable<Pedido> GetPedidosPorSucursal(int sucursalId)
        {
            return pedidoRepository.GetPedidosPorSucursal(sucursalId);
        }

        // 🔹 Pedidos por fecha
        public IEnumerable<Pedido> GetPedidosPorFecha(DateTime inicio, DateTime fin)
        {
            return pedidoRepository.GetPedidosPorFecha(inicio, fin);
        }

        // 🔹 Pedido completo (Cliente, Empleado, Detalles, Factura)
        public Pedido GetPedidoCompleto(int pedidoId)
        {
            return pedidoRepository.GetPedidoCompleto(pedidoId);
        }

        // 🔹 Calcular total del pedido
        public decimal CalcularTotalPedido(int pedidoId)
        {
            return pedidoRepository.CalcularTotalPedido(pedidoId);
        }

        // 🔹 Verificar stock antes de confirmar pedido
        public bool VerificarStock(int pedidoId)
        {
            return pedidoRepository.VerificarStock(pedidoId);
        }

        // 🔹 Actualizar stock después del pedido
        public void ActualizarStockDespuesDePedido(int pedidoId)
        {
            pedidoRepository.ActualizarStockDespuesDePedido(pedidoId);
        }

        // 🔹 Resumen de ventas por categoría
        public IEnumerable<object> GetResumenVentasPorCategoria()
        {
            return pedidoRepository.GetResumenVentasPorCategoria();
        }

        // 🔹 Generar factura desde pedido
        public Factura GenerarFacturaDesdePedido(int pedidoId)
        {
            return pedidoRepository.GenerarFacturaDesdePedido(pedidoId);
        }
    }
}


using CRUD_Consola._1Core.IRepository;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {
        }
        public IEnumerable<Pedido> GetPedidosConClienteYEmpleado()
        {
            return dbSet.Include(p => p.Cliente)
                        .Include(p => p.Empleado)
                        .Include(p => p.Detalles)
                        .ToList();
        }
        public IEnumerable<Pedido> GetPedidosPorCliente(int clienteId)
        {
            return context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                .Where(p => p.ClienteId == clienteId)
                .ToList();
        }

        public IEnumerable<Pedido> GetPedidosPorEmpleado(int empleadoId)
        {
            return context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                .Where(p => p.EmpleadoId == empleadoId)
                .ToList();
        }

        public IEnumerable<Pedido> GetPedidosPorSucursal(int sucursalId)
        {
            return context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                    .ThenInclude(e => e.Sucursal)
                .Where(p => p.Empleado.SucursalId == sucursalId)
                .ToList();
        }

        public IEnumerable<Pedido> GetPedidosPorFecha(DateTime inicio, DateTime fin)
        {
            return context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                .Where(p => p.Fecha >= inicio && p.Fecha <= fin)
                .ToList();
        }

        public Pedido GetPedidoCompleto(int pedidoId)
        {
            return context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                    .ThenInclude(e => e.Sucursal)
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                .Include(p => p.Factura)
                .FirstOrDefault(p => p.PedidoId == pedidoId);
        }

        public decimal CalcularTotalPedido(int pedidoId)
        {
            var pedido = context.Pedidos
                .Include(p => p.Detalles)
                .FirstOrDefault(p => p.PedidoId == pedidoId);

            if (pedido == null) return 0;

            return pedido.Detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
        }

        public bool VerificarStock(int pedidoId)
        {
            var pedido = context.Pedidos
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefault(p => p.PedidoId == pedidoId);

            if (pedido == null) return false;

            return pedido.Detalles.All(d => d.Producto.Stock >= d.Cantidad);
        }

        public void ActualizarStockDespuesDePedido(int pedidoId)
        {
            var pedido = context.Pedidos
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefault(p => p.PedidoId == pedidoId);

            if (pedido == null) return;

            foreach (var detalle in pedido.Detalles)
            {
                detalle.Producto.Stock -= detalle.Cantidad;
            }

            context.SaveChanges();
        }

        public IEnumerable<object> GetResumenVentasPorCategoria()
        {
            return context.Detalles
                .Include(d => d.Producto)
                    .ThenInclude(p => p.Categoria)
                .GroupBy(d => d.Producto.Categoria.Nombre)
                .Select(g => new
                {
                    Categoria = g.Key,
                    TotalVentas = g.Sum(d => d.Cantidad * d.PrecioUnitario)
                })
                .ToList();
        }

        public Factura GenerarFacturaDesdePedido(int pedidoId)
        {
            var pedido = context.Pedidos
                .Include(p => p.Detalles)
                .FirstOrDefault(p => p.PedidoId == pedidoId);

            if (pedido == null) return null;

            var montoTotal = pedido.Detalles.Sum(d => d.Cantidad * d.PrecioUnitario);

            var factura = new Factura
            {
                PedidoId = pedidoId,
                FechaEmision = DateTime.Now,
                MontoTotal = montoTotal
            };

            context.Facturas.Add(factura);
            context.SaveChanges();

            return factura;
        }
    }
}

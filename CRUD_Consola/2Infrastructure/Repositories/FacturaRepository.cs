using CRUD_Consola._1Core.IRepository;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    internal class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
        public FacturaRepository(AppDbContext context) : base(context)
        {
        }
        // Obtener factura por pedido
        public Factura GetByPedido(int pedidoId)
        {
            return context.Facturas
                .Include(f => f.Pedido)
                .FirstOrDefault(f => f.PedidoId == pedidoId);
        }

        // Listar facturas de un cliente
        public IEnumerable<Factura> GetByCliente(int clienteId)
        {
            return context.Facturas
                .Include(f => f.Pedido)
                .ThenInclude(p => p.Cliente)
                .Where(f => f.Pedido.ClienteId == clienteId)
                .ToList();
        }

        // Listar facturas en un rango de fechas
        public IEnumerable<Factura> GetByFecha(DateTime inicio, DateTime fin)
        {
            return context.Facturas
                .Where(f => f.FechaEmision >= inicio && f.FechaEmision <= fin)
                .ToList();
        }

        // Obtener factura con pagos
        public Factura GetWithPagos(int facturaId)
        {
            return context.Facturas
                .Include(f => f.Pagos)
                .FirstOrDefault(f => f.FacturaId == facturaId);
        }

        // Obtener boleta completa (Factura + Pedido + Detalles + Cliente + Empleado)
        public Factura GetBoletaCompleta(int facturaId)
        {
            return context.Facturas
                .Include(f => f.Pedido)
                    .ThenInclude(p => p.Cliente)
                .Include(f => f.Pedido)
                    .ThenInclude(p => p.Empleado)
                .Include(f => f.Pedido)
                    .ThenInclude(p => p.Detalles)
                        .ThenInclude(d => d.Producto)
                .Include(f => f.Pagos)
                .FirstOrDefault(f => f.FacturaId == facturaId);
        }
    }
}

using CRUD_Consola._1Core.IRepository;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    public class PagoRepository : Repository<Pago>, IPagoRepository
    {
        public PagoRepository(AppDbContext context) : base(context)
        {
        }
        // Listar pagos de una factura
        public IEnumerable<Pago> GetByFactura(int facturaId)
        {
            return context.Pagos
                .Where(p => p.FacturaId == facturaId)
                .ToList();
        }

        // Listar pagos en un rango de fechas
        public IEnumerable<Pago> GetByFecha(DateTime inicio, DateTime fin)
        {
            return context.Pagos
                .Where(p => p.FechaPago >= inicio && p.FechaPago <= fin)
                .ToList();
        }

        // Listar pagos por método (ej: "Tarjeta", "Efectivo")
        public IEnumerable<Pago> GetByMetodo(string metodoPago)
        {
            return context.Pagos
                .Where(p => p.MetodoPago == metodoPago)
                .ToList();
        }

        // Total pagado por una factura
        public decimal GetTotalPagadoPorFactura(int facturaId)
        {
            return context.Pagos
                .Where(p => p.FacturaId == facturaId)
                .Sum(p => p.Monto);
        }

        // Monto pendiente de una factura
        public decimal GetPendientePorFactura(int facturaId)
        {
            var factura = context.Facturas
                .Include(f => f.Pagos)
                .FirstOrDefault(f => f.FacturaId == facturaId);

            if (factura == null) return 0;

            var totalPagado = factura.Pagos.Sum(p => p.Monto);
            return factura.MontoTotal - totalPagado;
        }
    }
}

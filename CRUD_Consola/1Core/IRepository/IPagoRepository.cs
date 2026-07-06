using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IRepository
{
    public interface IPagoRepository : IRepository<Pago>
    {
        IEnumerable<Pago> GetByFactura(int facturaId);
        IEnumerable<Pago> GetByFecha(DateTime inicio, DateTime fin);
        IEnumerable<Pago> GetByMetodo(string metodoPago);
        decimal GetTotalPagadoPorFactura(int facturaId);
        decimal GetPendientePorFactura(int facturaId);
    }
}

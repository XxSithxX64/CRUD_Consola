using CRUD_Consola._1Core.IRepository;
using CRUD_Consola._1Core.IService;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services
{
    public class PagoService : Service<Pago>, IPagoService
    {
        private readonly IPagoRepository pagoRepository;

        public PagoService(IPagoRepository pagoRepository) : base(pagoRepository)
        {
            this.pagoRepository = pagoRepository;
        }
        // Listar pagos de una factura
        public IEnumerable<Pago> GetByFactura(int facturaId)
        {
            return pagoRepository.GetByFactura(facturaId);
        }

        // Listar pagos en un rango de fechas
        public IEnumerable<Pago> GetByFecha(DateTime inicio, DateTime fin)
        {
            return pagoRepository.GetByFecha(inicio, fin);
        }

        // Listar pagos por método (ej: "Tarjeta", "Efectivo")
        public IEnumerable<Pago> GetByMetodo(string metodoPago)
        {
            return pagoRepository.GetByMetodo(metodoPago);
        }

        // Total pagado por una factura
        public decimal GetTotalPagadoPorFactura(int facturaId)
        {
            return pagoRepository.GetTotalPagadoPorFactura(facturaId);
        }

        // Monto pendiente de una factura
        public decimal GetPendientePorFactura(int facturaId)
        {
            return pagoRepository.GetPendientePorFactura(facturaId);
        }
    }
}

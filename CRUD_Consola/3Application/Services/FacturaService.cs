using CRUD_Consola._1Core.IRepository;
using CRUD_Consola._1Core.IService;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services
{
    internal class FacturaService : Service<Factura>, IFacturaService
    {
        private readonly IFacturaRepository facturaRepository;
        public FacturaService(IFacturaRepository facturaRepository) : base(facturaRepository)
        {
            this.facturaRepository = facturaRepository;
        }
        public Factura GetByPedido(int pedidoId)
        {
            return facturaRepository.GetByPedido(pedidoId);
        }

        public IEnumerable<Factura> GetByCliente(int clienteId)
        {
            return facturaRepository.GetByCliente(clienteId);
        }

        public IEnumerable<Factura> GetByFecha(DateTime inicio, DateTime fin)
        {
            return facturaRepository.GetByFecha(inicio, fin);
        }

        public Factura GetWithPagos(int facturaId)
        {
            return facturaRepository.GetWithPagos(facturaId);
        }

        public Factura GetBoletaCompleta(int facturaId)
        {
            return facturaRepository.GetBoletaCompleta(facturaId);
        }
    }
}

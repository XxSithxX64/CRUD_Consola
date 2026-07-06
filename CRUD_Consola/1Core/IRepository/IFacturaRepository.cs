using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IRepository
{
    public interface IFacturaRepository : IRepository<Factura> 
    {
        Factura GetByPedido(int pedidoId);
        Factura GetWithPagos(int facturaId);
        Factura GetBoletaCompleta(int facturaId);
        IEnumerable<Factura> GetByCliente(int clienteId);
        IEnumerable<Factura> GetByFecha(DateTime inicio, DateTime fin);
    }
}

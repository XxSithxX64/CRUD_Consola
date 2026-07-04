using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.Core.Interfaces
{
    internal interface IFacturaRepository
    {
        Factura GetById(int id);
        IEnumerable<Factura> GetAll();
        void Add(Factura factura);
        void Update(Factura factura);
        void Delete(int id);

        Factura GetByPedido(int pedidoId);
    }
}

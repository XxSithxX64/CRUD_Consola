using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.Core.Interfaces
{
    internal interface IPagoRepository
    {
        Pago GetById(int id);
        IEnumerable<Pago> GetAll();
        void Add(Pago pago);
        void Update(Pago pago);
        void Delete(int id);

        IEnumerable<Pago> GetByFactura(int facturaId);
    }
}

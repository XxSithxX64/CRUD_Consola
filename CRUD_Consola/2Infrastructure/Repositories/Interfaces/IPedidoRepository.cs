using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.Core.Interfaces
{
    internal interface IPedidoRepository
    {
        Pedido GetById(int id);
        IEnumerable<Pedido> GetAll();
        void Add(Pedido pedido);
        void Update(Pedido pedido);
        void Delete(int id);

        IEnumerable<Pedido> GetByCliente(int clienteId);
        IEnumerable<Pedido> GetByEmpleado(int empleadoId);
    }
}

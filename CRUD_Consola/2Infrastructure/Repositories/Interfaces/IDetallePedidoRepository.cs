using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.Core.Interfaces
{
    internal interface IDetallePedidoRepository
    {
        DetallePedido GetById(int id);
        IEnumerable<DetallePedido> GetAll();
        void Add(DetallePedido detalle);
        void Update(DetallePedido detalle);
        void Delete(int id);

        IEnumerable<DetallePedido> GetByPedido(int pedidoId);
        IEnumerable<DetallePedido> GetByProducto(int productoId);
    }
}

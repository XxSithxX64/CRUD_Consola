using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IRepository
{
    public interface IDetallePedidoRepository : IRepository<DetallePedido>
    {
        IEnumerable<DetallePedido> ListarDetallePedido();
    }
}

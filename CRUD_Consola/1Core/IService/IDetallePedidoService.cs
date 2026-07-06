using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IService
{
    public interface IDetallePedidoService : IService<DetallePedido>
    {
        IEnumerable<DetallePedido> ObtenerDetallePedidoDetallado();
    }
}

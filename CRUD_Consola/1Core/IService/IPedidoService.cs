using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IService
{
    public interface IPedidoService : IService<Pedido>
    {
        IEnumerable<Pedido> ObtenerPedidosDetallados();>
    }
}

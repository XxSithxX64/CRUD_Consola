
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IRepository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        IEnumerable<Pedido> ListarConRelaciones();
    }
}

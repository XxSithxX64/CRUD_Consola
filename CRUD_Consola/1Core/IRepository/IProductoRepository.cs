using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IRepository
{
    public interface IProductoRepository : IRepository<Producto>
    {
        IEnumerable<Producto> ListarConRelaciones();
    }
}

using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IService
{
    public interface IProductoService : IService<Producto>
    {
        IEnumerable<Producto> ObtenerProductosDetallados();
    }
}

using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.Core.Interfaces
{
    internal interface IProductoRepository
    {
        Producto GetById(int id);
        IEnumerable<Producto> GetAll();
        void Add(Producto producto);
        void Update(Producto producto);
        void Delete(int id);

        IEnumerable<Producto> GetByCategoria(int categoriaId);
        IEnumerable<Producto> GetByProveedor(int proveedorId);
    }
}

using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services.Interfaces
{
    internal interface IProductoService
    {
        Producto BuscarProducto(int id);
        IEnumerable<Producto> ListarProductos();
        void CrearProducto(Producto producto);
        void ActualizarProducto(Producto producto);
        void EliminarProducto(int id);
        IEnumerable<Producto> ListarPorCategoria(int categoriaId);
        IEnumerable<Producto> ListarPorProveedor(int proveedorId);
    }
}

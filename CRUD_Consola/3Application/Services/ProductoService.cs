using CRUD_Consola._3Application.Services.Interfaces;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Core.Interfaces;

namespace CRUD_Consola._3Application.Services
{
    internal class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        public Producto BuscarProducto(int id)
        {
            return productoRepository.GetById(id);
        }

        public IEnumerable<Producto> ListarProductos()
        {
            return productoRepository.GetAll();
        }

        public void CrearProducto(Producto producto)
        {
            productoRepository.Add(producto);
        }

        public void ActualizarProducto(Producto producto)
        {
            productoRepository.Update(producto);
        }

        public void EliminarProducto(int id)
        {
            productoRepository.Delete(id);
        }

        public IEnumerable<Producto> ListarPorCategoria(int categoriaId)
        {
            return productoRepository.GetByCategoria(categoriaId);
        }

        public IEnumerable<Producto> ListarPorProveedor(int proveedorId)
        {
            return productoRepository.GetByProveedor(proveedorId);
        }
    }
}

using CRUD_Consola._1Core.IRepository;
using CRUD_Consola._1Core.IService;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services
{
    public class ProductoService : Service<Producto>, IProductoService
    {
        private readonly IProductoRepository productoRepository;
        public ProductoService(IProductoRepository productoRepository) : base(productoRepository)
        {
            this.productoRepository = productoRepository;
        }
        public IEnumerable<Producto> ObtenerProductosDetallados()
        {
            return productoRepository.ListarConRelaciones();
        }
    }
}

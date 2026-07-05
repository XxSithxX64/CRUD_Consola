using CRUD_Consola._2.Infrastructure.Repositories;
using CRUD_Consola._2Infrastructure.Repositories;
using CRUD_Consola._3.Application.Services.Interfaces;
using CRUD_Consola._3Application.Services;
using CRUD_Consola._3Application.Services.Interfaces;
using CRUD_Consola.Application.Services;
using CRUD_Consola.Infrastructure.Data;

namespace CRUD_Consola._3Application.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        //UnitOfWork con Lazy Loading
        private readonly AppDbContext context;

        private IClienteService? _clienteService; //? el signo asume que puede ser nulo, y evita el warning de compilación
        private ISucursalService? _sucursalService;
        private IProveedorService? _proveedorService;
        private ICategoriaService? _categoriaService;
        private IProductoService? _productoService;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }


        //??=si _clienteService es nulo, créalo; si ya existe, úsalo
        public IClienteService ClienteService =>
        _clienteService ??= new ClienteService(new ClienteRepository(context));

        public ISucursalService SucursalService =>
            _sucursalService ??= new SucursalService(new SucursalRepository(context));

        public IProveedorService ProveedorService =>
            _proveedorService ??= new ProveedorService(new ProveedorRepository(context));

        public ICategoriaService CategoriaService =>
            _categoriaService ??= new CategoriaService(new CategoriaRepository(context));

        public IProductoService ProductoService =>
            _productoService ??= new ProductoService(new ProductoRepository(context));
    }
}

using CRUD_Consola._1Core.IService;
using CRUD_Consola._2Infrastructure.Repositories;
using CRUD_Consola._3Application.Services;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;

namespace CRUD_Consola._3Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //UnitOfWork con Lazy Loading
        private readonly AppDbContext context;

        private IService<Cliente>? _clienteService; //? el signo asume que puede ser nulo, y evita el warning de compilación
        private IService<Sucursal>? _sucursalService;
        private IService<Proveedor>? _proveedorService;
        private IService<Categoria>? _categoriaService;
        private IProductoService? _productoService;
        private IEmpleadoService? _empleadoService;
        private IPedidoService? _pedidoService;
        private IDetallePedidoService? _detallePedidoService;
        private IFacturaService? _facturaService;
        private IPagoService? _pagoService;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }


        //??=si _clienteService es nulo, créalo; si ya existe, úsalo
        public IService<Cliente> ClienteService =>
        _clienteService ??= new Service<Cliente>(new Repository<Cliente>(context));

        public IService<Sucursal> SucursalService =>
            _sucursalService ??= new Service<Sucursal>(new Repository<Sucursal>(context));

        public IService<Proveedor> ProveedorService =>
            _proveedorService ??= new Service<Proveedor>(new Repository<Proveedor>(context));

        public IService<Categoria> CategoriaService =>
            _categoriaService ??= new Service<Categoria>(new Repository<Categoria>(context));

        public IProductoService ProductoService =>
            _productoService ??= new ProductoService(new ProductoRepository(context));         

        public IPedidoService IPedidoService =>
            _pedidoService ??= new PedidoService(new PedidoRepository(context));

        public IEmpleadoService EmpleadoService =>
            _empleadoService ??= new EmpleadoService(new EmpleadoRepository(context));

        public IPedidoService PedidoService => 
            _pedidoService ??= new PedidoService(new PedidoRepository(context));

        public IDetallePedidoService DetallePedidoService =>
            _detallePedidoService ??= new DetallePedidoService(new DetallePedidoRepository(context));

        public IFacturaService FacturaService => 
            _facturaService ??= new FacturaService(new FacturaRepository(context));

        public IPagoService PagoService => 
            _pagoService ??= new PagoService(new PagoRepository(context));

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

using CRUD_Consola._1Core.IService;
using CRUD_Consola._2Infrastructure.Repositories;
using CRUD_Consola._3Application.Services;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola._3Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //UnitOfWork con Lazy Loading
        private readonly AppDbContext _context;
        private readonly IService<Cliente> _clienteService; //IService<Cliente>? el signo asume que puede ser nulo, y evita el warning de compilación
        private readonly IService<Sucursal> _sucursalService;
        private readonly IService<Proveedor> _proveedorService;
        private readonly IService<Categoria> _categoriaService;
        private readonly IProductoService _productoService;
        private readonly IEmpleadoService _empleadoService;
        private readonly IPedidoService _pedidoService;
        private readonly IDetallePedidoService _detallePedidoService;
        private readonly IFacturaService _facturaService;
        private readonly IPagoService? _pagoService;

        public UnitOfWork(
        AppDbContext context,
        IService<Cliente> clienteService,
        IService<Sucursal> sucursalService,
        IService<Proveedor> proveedorService,
        IService<Categoria> categoriaService,
        IProductoService productoService,
        IEmpleadoService empleadoService,
        IPedidoService pedidoService,
        IDetallePedidoService detallePedidoService,
        IFacturaService facturaService,
        IPagoService pagoService)
        {
            _context = context;
            _clienteService = clienteService;
            _sucursalService = sucursalService;
            _proveedorService = proveedorService;
            _categoriaService = categoriaService;
            _productoService = productoService;
            _empleadoService = empleadoService;
            _pedidoService = pedidoService;
            _detallePedidoService = detallePedidoService;
            _facturaService = facturaService;
            _pagoService = pagoService;
        }

        public IService<Cliente> ClienteService => _clienteService;
        public IService<Sucursal> SucursalService => _sucursalService;
        public IService<Proveedor> ProveedorService => _proveedorService;
        public IService<Categoria> CategoriaService => _categoriaService;
        public IProductoService ProductoService => _productoService;
        public IEmpleadoService EmpleadoService => _empleadoService;
        public IPedidoService PedidoService => _pedidoService;
        public IDetallePedidoService DetallePedidoService => _detallePedidoService;
        public IFacturaService FacturaService => _facturaService;
        public IPagoService PagoService => _pagoService;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

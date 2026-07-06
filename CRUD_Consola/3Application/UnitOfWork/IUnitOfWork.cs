using CRUD_Consola._1Core.IService;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        IService<Cliente> ClienteService { get; }
        IService<Sucursal>SucursalService { get; }
        IService<Proveedor>ProveedorService { get; }
        IService<Categoria> CategoriaService { get; }
        IProductoService ProductoService { get; }
        IEmpleadoService EmpleadoService { get; }
        IPedidoService PedidoService { get; }
        IDetallePedidoService DetallePedidoService { get; }
        IFacturaService FacturaService { get; }
        IPagoService PagoService { get; }
        void SaveChanges();
    }
}

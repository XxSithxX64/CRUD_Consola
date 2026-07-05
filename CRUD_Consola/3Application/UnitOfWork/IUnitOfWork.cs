using CRUD_Consola._3.Application.Services.Interfaces;
using CRUD_Consola._3Application.Services.Interfaces;

namespace CRUD_Consola._3Application.UnitOfWork
{
    internal interface IUnitOfWork
    {
        IClienteService ClienteService { get; }
        ISucursalService SucursalService { get; }
        IProveedorService ProveedorService { get; }
        ICategoriaService CategoriaService { get; }
        IProductoService ProductoService { get; }
    }
}

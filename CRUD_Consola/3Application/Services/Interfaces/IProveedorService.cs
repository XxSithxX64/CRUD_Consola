using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services.Interfaces
{
    internal interface IProveedorService
    {
        void CrearProveedor(Proveedor proveedor);
        IEnumerable<Proveedor> ListarProveedores();
        Proveedor BuscarProveedor(int id);
        void ActualizarProveedor(Proveedor proveedor);
        void EliminarProveedor(int id);
    }
}

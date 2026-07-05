using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services.Interfaces
{
    internal interface ISucursalService
    {
        void CrearSucursal(Sucursal sucursal);
        IEnumerable<Sucursal> ListarSucursales();
        Sucursal BuscarSucursal(int id);
        void ActualizarSucursal(Sucursal sucursal);
        void EliminarSucursal(int id);
    }
}

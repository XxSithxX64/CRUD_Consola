using CRUD_Consola._3Application.Services.Interfaces;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Core.Interfaces;

namespace CRUD_Consola._3Application.Services
{
    internal class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository repo;

        public SucursalService(ISucursalRepository repo)
        {
            this.repo = repo;
        }

        public void CrearSucursal(Sucursal sucursal) => repo.Add(sucursal);
        public IEnumerable<Sucursal> ListarSucursales() => repo.GetAll();
        public Sucursal BuscarSucursal(int id) => repo.GetById(id);
        public void ActualizarSucursal(Sucursal sucursal) => repo.Update(sucursal);
        public void EliminarSucursal(int id) => repo.Delete(id);
    }
}

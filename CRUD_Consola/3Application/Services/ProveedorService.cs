using CRUD_Consola._3Application.Services.Interfaces;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Core.Interfaces;

namespace CRUD_Consola._3Application.Services
{
    internal class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository repo;

        public ProveedorService(IProveedorRepository repo)
        {
            this.repo = repo;
        }

        public void CrearProveedor(Proveedor proveedor) => repo.Add(proveedor);
        public IEnumerable<Proveedor> ListarProveedores() => repo.GetAll();
        public Proveedor BuscarProveedor(int id) => repo.GetById(id);
        public void ActualizarProveedor(Proveedor proveedor) => repo.Update(proveedor);
        public void EliminarProveedor(int id) => repo.Delete(id);
    }
}

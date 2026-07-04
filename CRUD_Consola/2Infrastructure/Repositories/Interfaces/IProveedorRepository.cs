using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.Core.Interfaces
{
    internal interface IProveedorRepository
    {
        Proveedor GetById(int id);
        IEnumerable<Proveedor> GetAll();
        void Add(Proveedor proveedor);
        void Update(Proveedor proveedor);
        void Delete(int id);
    }
}

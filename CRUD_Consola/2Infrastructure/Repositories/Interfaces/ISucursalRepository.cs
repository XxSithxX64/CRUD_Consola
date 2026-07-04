using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.Core.Interfaces
{
    internal interface ISucursalRepository
    {
        Sucursal GetById(int id);
        IEnumerable<Sucursal> GetAll();
        void Add(Sucursal sucursal);
        void Update(Sucursal sucursal);
        void Delete(int id);
    }
}

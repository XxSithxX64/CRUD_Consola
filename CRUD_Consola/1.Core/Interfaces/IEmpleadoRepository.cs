using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.Core.Interfaces
{
    internal interface IEmpleadoRepository
    {
        Empleado GetById(int id);
        IEnumerable<Empleado> GetAll();
        void Add(Empleado empleado);
        void Update(Empleado empleado);
        void Delete(int id);

        IEnumerable<Empleado> GetBySucursal(int sucursalId);
    }
}

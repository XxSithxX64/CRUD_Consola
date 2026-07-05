using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IRepository
{
    internal interface IEmpleadoRepository : IRepository<Empleado>
    {
        IEnumerable<Empleado> ListarConRelaciones();
    }
}

using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1Core.IService
{
    public interface IEmpleadoService : IService<Empleado>
    {
        IEnumerable<Empleado> ObtenerSucursalDetallados();
    }
}

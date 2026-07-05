using CRUD_Consola._1Core.IRepository;
using CRUD_Consola._1Core.IService;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services
{
    internal class EmpleadoService : Service<Empleado>, IEmpleadoService
    {
        private readonly IEmpleadoRepository empleadoRepository;
        public EmpleadoService(IEmpleadoRepository empleadoRepository) : base(empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
        }

        // Implement any additional methods specific to EmpleadoService here
    }
}

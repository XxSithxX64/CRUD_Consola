using CRUD_Consola._1Core.IRepository;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    internal class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(AppDbContext context) : base(context)
        {
        }
        public IEnumerable<Empleado> ListarConRelaciones()
        {
            return dbSet.Include(e => e.Sucursal)
                        .ToList();
        }
    }
}

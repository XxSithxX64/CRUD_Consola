using CRUD_Consola.Core.Entities;
using CRUD_Consola.Core.Interfaces;
using CRUD_Consola.Infrastructure.Data;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    internal class SucursalRepository: ISucursalRepository
    {
        private readonly AppDbContext context;

        public SucursalRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Sucursal GetById(int id) => context.Sucursales.Find(id);

        public IEnumerable<Sucursal> GetAll() => context.Sucursales.ToList();

        public void Add(Sucursal entidad)
        {
            context.Sucursales.Add(entidad);
            context.SaveChanges();
        }

        public void Update(Sucursal entidad)
        {
            context.Sucursales.Update(entidad);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sucursal = context.Sucursales.Find(id);
            if (sucursal != null)
            {
                context.Sucursales.Remove(sucursal);
                context.SaveChanges();
            }
        }
    }
}

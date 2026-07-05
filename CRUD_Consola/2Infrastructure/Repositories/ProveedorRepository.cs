using CRUD_Consola.Core.Entities;
using CRUD_Consola.Core.Interfaces;
using CRUD_Consola.Infrastructure.Data;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    internal class ProveedorRepository : IProveedorRepository
    {
        private readonly AppDbContext context;

        public ProveedorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Proveedor GetById(int id) => context.Proveedores.Find(id);

        public IEnumerable<Proveedor> GetAll() => context.Proveedores.ToList();

        public void Add(Proveedor proveedor)
        {
            context.Proveedores.Add(proveedor);
            context.SaveChanges();
        }

        public void Update(Proveedor proveedor)
        {
            context.Proveedores.Update(proveedor);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var proveedor = context.Proveedores.Find(id);
            if (proveedor != null)
            {
                context.Proveedores.Remove(proveedor);
                context.SaveChanges();
            }
        }
    }
}

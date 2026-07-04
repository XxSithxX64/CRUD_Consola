using CRUD_Consola._1.Core.Interfaces;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;

namespace CRUD_Consola._2.Infrastructure.Repositories
{
    internal class ClienteRepository : IPersonaRepository<Cliente>
    {
        private readonly AppDbContext context;

        public ClienteRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Cliente GetById(int id) => context.Clientes.Find(id);

        public IEnumerable<Cliente> GetAll() => context.Clientes.ToList();

        public void Add(Cliente entidad)
        {
            context.Clientes.Add(entidad);
            context.SaveChanges();
        }

        public void Update(Cliente entidad)
        {
            context.Clientes.Update(entidad);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = context.Clientes.Find(id);
            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                context.SaveChanges();
            }
        }
    }
}

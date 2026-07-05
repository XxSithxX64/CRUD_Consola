using CRUD_Consola.Core.Entities;
using CRUD_Consola.Core.Interfaces;
using CRUD_Consola.Infrastructure.Data;
namespace CRUD_Consola._2Infrastructure.Repositories
{
    internal class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext context;

        public CategoriaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Categoria GetById(int id) => context.Categorias.Find(id);
        public IEnumerable<Categoria> GetAll() => context.Categorias.ToList();
        public void Add(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
        }
        public void Update(Categoria categoria)
        {
            context.Categorias.Update(categoria);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var categoria = context.Categorias.Find(id);
            if (categoria != null)
            {
                context.Categorias.Remove(categoria);
                context.SaveChanges();
            }
        }
    }
}

using CRUD_Consola._1Core.IRepository;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext context;
        protected readonly DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => dbSet.ToList();
        public T GetById(int id) => dbSet.Find(id);
        public void Add(T entity) => dbSet.Add(entity);
        public void Update(T entity) => dbSet.Update(entity);
        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null) dbSet.Remove(entity);
        }
    }
}

using CRUD_Consola._1Core.IRepository;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    internal class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(AppDbContext context) : base(context)
        {
        }
        public IEnumerable<Producto> ListarConRelaciones()
        {
            return dbSet.Include(p => p.Categoria)
                        .Include(p => p.Proveedor)
                        .ToList();
        }       
    }
}

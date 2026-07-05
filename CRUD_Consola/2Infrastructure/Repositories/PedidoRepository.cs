
using CRUD_Consola._1Core.IRepository;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {
        }
        public IEnumerable<Pedido> ListarConRelaciones()
        {
            return dbSet.Include(p => p.Cliente)
                        .Include(p => p.Detalles)
                        .ToList();
        }
    }
}

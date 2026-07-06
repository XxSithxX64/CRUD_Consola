using CRUD_Consola._1Core.IRepository;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    public class DetallePedidoRepository : Repository<DetallePedido>, IDetallePedidoRepository     
    {
        public DetallePedidoRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<DetallePedido> ListarDetallePedido()
        {
            return dbSet.Include(d => d.Producto)
                            .ThenInclude(p => p.Categoria)
                        .Include(d => d.Producto)
                            .ThenInclude(p => p.Proveedor)
                        .Include(d => d.Pedido)
                            .ThenInclude(p => p.Cliente)
                        .Include(d => d.Pedido)
                            .ThenInclude(p => p.Empleado)
                            .ThenInclude(e => e.Sucursal)
                        .ToList();
        }
    }
}

using CRUD_Consola.Core.Entities;
using CRUD_Consola.Core.Interfaces;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola._2Infrastructure.Repositories
{
    internal class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext context;

        public ProductoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Producto GetById(int id) => context.Productos.Find(id);
        public IEnumerable<Producto> GetAll() => context.Productos.ToList();
        public void Add(Producto producto)
        {
            context.Productos.Add(producto);
            context.SaveChanges();
        }
        public void Update(Producto producto)
        {
            context.Productos.Update(producto);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var producto = context.Productos.Find(id);
            if (producto != null)
            {
                context.Productos.Remove(producto);
                context.SaveChanges();
            }
        }

        public IEnumerable<Producto> GetByCategoria(int categoriaId)
        {
            return context.Productos
                           .Where(p => p.CategoriaId == categoriaId)
                           .Include(p => p.Categoria)
                           .ToList();
        }

        public IEnumerable<Producto> GetByProveedor(int proveedorId)
        {
            return context.Productos
                           .Where(p => p.ProveedorId == proveedorId)
                           .Include(p => p.Proveedor)
                           .ToList();
        }
    }
}

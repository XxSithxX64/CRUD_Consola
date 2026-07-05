using CRUD_Consola._3Application.Services.Interfaces;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Core.Interfaces;

namespace CRUD_Consola._3Application.Services
{
    internal class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository repo;

        public CategoriaService(ICategoriaRepository repo)
        {
            this.repo = repo;
        }

        public void CrearCategoria(Categoria categoria) => repo.Add(categoria);
        public IEnumerable<Categoria> ListarCategorias() => repo.GetAll();
        public Categoria BuscarCategoria(int id) => repo.GetById(id);
        public void ActualizarCategoria(Categoria categoria) => repo.Update(categoria);
        public void EliminarCategoria(int id) => repo.Delete(id);
    }
}

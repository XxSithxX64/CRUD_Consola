using CRUD_Consola._1Core.IRepository;
using CRUD_Consola._1Core.IService;

namespace CRUD_Consola._3Application.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> repository;

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> Listar() => repository.GetAll();
        public T Buscar(int id) => repository.GetById(id);
        public void Crear(T entidad) => repository.Add(entidad);
        public void Actualizar(T entidad) => repository.Update(entidad);
        public void Eliminar(int id) => repository.Delete(id);
    }
}

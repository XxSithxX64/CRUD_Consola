using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._1.Core.Interfaces
{
    internal interface IPersonaRepository<T> where T : Persona
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entidad);
        void Update(T entidad);
        void Delete(int id);
    }
}

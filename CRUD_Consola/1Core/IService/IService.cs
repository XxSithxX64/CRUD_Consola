namespace CRUD_Consola._1Core.IService
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> Listar();
        T Buscar(int id);
        void Crear(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
    }
}

using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services.Interfaces
{
    internal interface ICategoriaService
    {
        void CrearCategoria(Categoria categoria);
        IEnumerable<Categoria> ListarCategorias();
        Categoria BuscarCategoria(int id);
        void ActualizarCategoria(Categoria categoria);
        void EliminarCategoria(int id);
    }
}

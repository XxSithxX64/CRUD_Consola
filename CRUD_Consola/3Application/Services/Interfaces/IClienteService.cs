using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3.Application.Services.Interfaces
{
    internal interface IClienteService
    {
        void CrearCliente(Cliente cliente);
        IEnumerable<Cliente> ListarClientes();
        Cliente BuscarCliente(int id);
        void ActualizarCliente(Cliente cliente);
        void EliminarCliente(int id);
    }
}

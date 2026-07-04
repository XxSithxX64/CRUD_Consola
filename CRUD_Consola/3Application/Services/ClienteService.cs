using CRUD_Consola._1.Core.Interfaces;
using CRUD_Consola._3.Application.Services.Interfaces;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.Application.Services
{
    internal class ClienteService : IClienteService
    {
        private readonly IPersonaRepository<Cliente> repo;

        public ClienteService(IPersonaRepository<Cliente> repo)
        {
            this.repo = repo;
        }

        public void CrearCliente(Cliente cliente) => repo.Add(cliente);
        public IEnumerable<Cliente> ListarClientes() => repo.GetAll();
        public Cliente BuscarCliente(int id) => repo.GetById(id);
        public void ActualizarCliente(Cliente cliente) => repo.Update(cliente);
        public void EliminarCliente(int id) => repo.Delete(id);
    }
}

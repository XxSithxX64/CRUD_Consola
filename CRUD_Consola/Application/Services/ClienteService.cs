
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Core.Interfaces;

namespace CRUD_Consola.Application.Services
{
    internal class ClienteService
    {
        private readonly IClienteRepository repo;

        public ClienteService(IClienteRepository repo)
        {
            this.repo = repo;
        }

        public void CrearCliente(string nombre, string email, string telefono)
        {
            var cliente = new Cliente { Nombre = nombre, Email = email, Telefono = telefono };
            repo.Add(cliente);
        }

        public IEnumerable<Cliente> ListarClientes() => repo.GetAll();

        public Cliente BuscarCliente(int id) => repo.GetById(id);

        public void ActualizarCliente(int id, string nuevoNombre)
        {
            var cliente = repo.GetById(id);
            if (cliente != null)
            {
                cliente.Nombre = nuevoNombre;
                repo.Update(cliente);
            }
        }

        public void EliminarCliente(int id) => repo.Delete(id);
    }
}

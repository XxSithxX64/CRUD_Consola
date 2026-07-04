using CRUD_Consola.Application.Services;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.UI
{
    internal class ClienteConsoleUI
    {
        private readonly ClienteService _clienteService;

        public ClienteConsoleUI(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n=== CRUD Clientes ===");
                Console.WriteLine("1. Crear Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Buscar Cliente por ID");
                Console.WriteLine("4. Actualizar Cliente");
                Console.WriteLine("5. Eliminar Cliente");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": CrearClienteUI(); break;
                    case "2": ListarClientesUI(); break;
                    case "3": BuscarClienteUI(); break;
                    case "4": ActualizarClienteUI(); break;
                    case "5": EliminarClienteUI(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        private void CrearClienteUI()
        {
            var cliente = CapturarDatosCliente();
            _clienteService.CrearCliente(cliente);
            Console.WriteLine("✅ Cliente registrado correctamente.");
        }

        private void ListarClientesUI()
        {
            var clientes = _clienteService.ListarClientes();
            foreach (var c in clientes)
                Console.WriteLine($"{c.PersonaId} - {c.Nombres} {c.ApellidoPat} {c.ApellidoMat} ({c.Email})");
        }

        private void BuscarClienteUI()
        {
            Console.Write("Ingrese ID del cliente: ");
            int id = int.Parse(Console.ReadLine());
            var cliente = _clienteService.BuscarCliente(id);
            if (cliente != null)
                Console.WriteLine($"{cliente.PersonaId} - {cliente.Nombres} {cliente.ApellidoPat} {cliente.ApellidoMat} ({cliente.Email})");
            else
                Console.WriteLine("❌ Cliente no encontrado.");
        }

        private void ActualizarClienteUI()
        {
            Console.Write("Ingrese ID del cliente a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            var cliente = _clienteService.BuscarCliente(id);

            if (cliente == null)
            {
                Console.WriteLine("❌ Cliente no encontrado.");
                return;
            }

            Console.WriteLine("Ingrese nuevos datos (dejar vacío para mantener el actual):");

            Console.Write($"Nombres ({cliente.Nombres}): ");
            var nombres = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombres)) cliente.Nombres = nombres;

            Console.Write($"Apellido Paterno ({cliente.ApellidoPat}): ");
            var apellidoPat = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apellidoPat)) cliente.ApellidoPat = apellidoPat;

            Console.Write($"Apellido Materno ({cliente.ApellidoMat}): ");
            var apellidoMat = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apellidoMat)) cliente.ApellidoMat = apellidoMat;

            Console.Write($"Email ({cliente.Email}): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) cliente.Email = email;

            _clienteService.ActualizarCliente(cliente);
            Console.WriteLine("✅ Cliente actualizado correctamente.");
        }

        private void EliminarClienteUI()
        {
            Console.Write("Ingrese ID del cliente a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            _clienteService.EliminarCliente(id);
            Console.WriteLine("✅ Cliente eliminado correctamente.");
        }

        private Cliente CapturarDatosCliente()
        {
            Console.Write("Nombres: ");
            var nombres = Console.ReadLine();

            Console.Write("Apellido Paterno: ");
            var apellidoPat = Console.ReadLine();

            Console.Write("Apellido Materno: ");
            var apellidoMat = Console.ReadLine();

            Console.Write("Documento Identidad: ");
            var docIdentidad = Console.ReadLine();

            Console.Write("Fecha Nacimiento (yyyy-MM-dd): ");
            var fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Teléfono: ");
            var telefono = Console.ReadLine();

            Console.Write("Dirección: ");
            var direccion = Console.ReadLine();

            return new Cliente
            {
                Nombres = nombres,
                ApellidoPat = apellidoPat,
                ApellidoMat = apellidoMat,
                DocIdentidad = docIdentidad,
                FechaNacimiento = fechaNacimiento,
                Email = email,
                Telefono = telefono,
                Direccion = direccion,

                // Campos propios de Cliente
                FechaRegistro = DateTime.Now, // registra la fecha actual
                Activo = true                 // el cliente se crea activo por defecto
            };
        }
    }
}

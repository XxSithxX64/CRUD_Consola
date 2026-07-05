using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola.UI
{
    public class ClienteConsoleUI
    {
        private readonly IUnitOfWork _uow;

        public ClienteConsoleUI(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== CRUD Clientes ===");
                Console.WriteLine("1. Crear Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Buscar Cliente por ID");
                Console.WriteLine("4. Actualizar Cliente");
                Console.WriteLine("5. Eliminar Cliente");
                Console.WriteLine("0. Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1": Console.Clear(); CrearClienteUI(); break;
                    case "2": Console.Clear(); ListarClientesUI(); break;
                    case "3": Console.Clear(); BuscarClienteUI(); break;
                    case "4": Console.Clear(); ActualizarClienteUI(); break;
                    case "5": Console.Clear(); EliminarClienteUI(); break;
                    case "0": salir = true; break;
                    default: Console.Clear(); Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        private void CrearClienteUI()
        {
            Console.WriteLine("Ingrese los datos del cliente:");
            Console.WriteLine("------------------------------");
            var cliente = CapturarDatosCliente();
            _uow.ClienteService.Crear(cliente);
            _uow.SaveChanges();
            Console.WriteLine("✅ Cliente registrado correctamente.");
            Console.WriteLine();
        }

        private void ListarClientesUI()
        {
            Console.WriteLine("Lista de Clientes:");
            Console.WriteLine("------------------");
            var clientes = _uow.ClienteService.Listar();
            foreach (var c in clientes)
                //Console.WriteLine($"{c.PersonaId} - {c.Nombres} {c.ApellidoPat} {c.ApellidoMat} ({c.Email})");
                Console.WriteLine(c.ToString());
            Console.WriteLine();
        }

        private void BuscarClienteUI()
        {
            Console.WriteLine("Buscar Cliente por ID:");
            Console.WriteLine("----------------------");
            Console.Write("Ingrese ID del cliente: ");
            int id = int.Parse(Console.ReadLine());
            var cliente = _uow.ClienteService.Buscar(id);
            if (cliente != null)
                Console.WriteLine(cliente.ToString());
            else
                Console.WriteLine("❌ Cliente no encontrado.");
            Console.WriteLine();
        }

        private void ActualizarClienteUI()
        {
            Console.WriteLine("Actualizar Cliente:");
            Console.WriteLine("-------------------");
            Console.Write("Ingrese ID del cliente a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            var cliente = _uow.ClienteService.Buscar(id);

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

            Console.Write($"Documento de Identidad ({cliente.DocIdentidad}): ");
            var docIdentidad = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(docIdentidad)) cliente.DocIdentidad = docIdentidad;

            Console.Write($"Email ({cliente.Email}): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) cliente.Email = email;

            Console.Write($"Telefono ({cliente.Telefono}): ");
            var telefono = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(telefono)) cliente.Telefono = telefono;

            Console.Write($"Direccion ({cliente.Direccion}): ");
            var direccion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(direccion)) cliente.Direccion = direccion;

            Console.Write($"Activo ({cliente.Activo})(s/n): ");
            var activo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(activo))
                cliente.Activo = activo.Trim().ToLower() == "s" || activo.Trim().ToLower() == "true";

            _uow.ClienteService.Actualizar(cliente);
            _uow.SaveChanges();
            Console.WriteLine("✅ Cliente actualizado correctamente.");
            Console.WriteLine();
        }

        private void EliminarClienteUI()
        {
            Console.WriteLine("Eliminar Cliente:");
            Console.WriteLine("-----------------");
            Console.Write("Ingrese ID del cliente a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            _uow.ClienteService.Eliminar(id);
            _uow.SaveChanges();
            Console.WriteLine("✅ Cliente eliminado correctamente.");
            Console.WriteLine();
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

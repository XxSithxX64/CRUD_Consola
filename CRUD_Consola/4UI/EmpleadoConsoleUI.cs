using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._4UI
{
    public class EmpleadoConsoleUI
    {
        private readonly IUnitOfWork _uow;

        public EmpleadoConsoleUI(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== CRUD Empleados ===");
                Console.WriteLine("1. Crear Empleado");
                Console.WriteLine("2. Listar Empleados");
                Console.WriteLine("3. Buscar Empleado por ID");
                Console.WriteLine("4. Actualizar Empleado");
                Console.WriteLine("5. Eliminar Empleado");
                Console.WriteLine("6. Listar Empleados Detallados (con Sucursal)");
                Console.WriteLine("0. Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();
                Console.WriteLine();
                switch (opcion)
                {
                    case "1": Console.Clear(); CrearEmpleadoUI(); break;
                    case "2": Console.Clear(); ListarEmpleadosUI(); break;
                    case "3": Console.Clear(); BuscarEmpleadoUI(); break;
                    case "4": Console.Clear(); ActualizarEmpleadoUI(); break;
                    case "5": Console.Clear(); EliminarEmpleadoUI(); break;
                    case "6": Console.Clear(); ListarEmpleadosDetalladosUI(); break;
                    case "0": salir = true; break;
                    default: Console.Clear(); Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        private void CrearEmpleadoUI()
        {
            Console.WriteLine("Ingrese los datos del empleado:");
            Console.WriteLine("------------------------------");
            var empleado = CapturarDatosEmpleado();
            _uow.EmpleadoService.Crear(empleado);
            _uow.SaveChanges();
            Console.WriteLine("✅ Empleado registrado correctamente.");
            Console.WriteLine();
        }

        private void ListarEmpleadosUI()
        {
            Console.WriteLine("Lista de Empleados:");
            Console.WriteLine("-------------------");
            var empleados = _uow.EmpleadoService.Listar();
            foreach (var e in empleados)
                Console.WriteLine(e.ToString());
            Console.WriteLine();
        }

        private void BuscarEmpleadoUI()
        {
            Console.WriteLine("Buscar Empleado por ID:");
            Console.WriteLine("-----------------------");
            Console.Write("Ingrese el ID del empleado: ");
            int id = int.Parse(Console.ReadLine());
            var empleado = _uow.EmpleadoService.Buscar(id);
            if (empleado != null)
                Console.WriteLine(empleado.ToString());
            else
                Console.WriteLine("❌ ID inválido.");
            Console.WriteLine();
        }

        private void ActualizarEmpleadoUI()
        {
            Console.WriteLine("Actualizar Empleado:");
            Console.WriteLine("--------------------");
            Console.Write("Ingrese el ID del empleado a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            var empleado = _uow.EmpleadoService.Buscar(id);
            if (empleado == null)
            {
                Console.WriteLine("❌ Empleado no encontrado.");
                return;
            }
            Console.WriteLine("Ingrese nuevos datos (dejar vacío para mantener el actual):");

            Console.Write($"Nombre ({empleado.Nombres}): ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) empleado.Nombres = nombre;

            Console.Write($"Apellido Paterno ({empleado.ApellidoPat}): ");
            var apellidoPat = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apellidoPat)) empleado.ApellidoPat = apellidoPat;

            Console.Write($"Apellido Materno ({empleado.ApellidoMat}): ");
            var apellidoMat = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apellidoMat)) empleado.ApellidoMat = apellidoMat;

            Console.Write($"Documento de Identidad ({empleado.DocIdentidad}): ");
            var docIdentidad = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(docIdentidad)) empleado.DocIdentidad = docIdentidad;

            Console.Write($"Email ({empleado.Email}): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) empleado.Email = email;

            Console.Write($"Telefono ({empleado.Telefono}): ");
            var telefono = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(telefono)) empleado.Telefono = telefono;

            Console.Write($"Direccion ({empleado.Direccion}): ");
            var direccion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(direccion)) empleado.Direccion = direccion;

            Console.Write($"Cargo ({empleado.Cargo}): ");
            var cargo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(cargo)) empleado.Cargo = cargo;

            _uow.EmpleadoService.Actualizar(empleado);
            _uow.SaveChanges();
            Console.WriteLine("✅ Empleado actualizado correctamente.");
            Console.ReadLine();
        }

        private void EliminarEmpleadoUI()
        {
            Console.WriteLine("Eliminar Empleado:");
            Console.WriteLine("------------------");
            Console.Write("Ingrese el ID del empleado a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            _uow.EmpleadoService.Eliminar(id);
            _uow.SaveChanges();
            Console.WriteLine("✅ Empleado eliminado correctamente.");
            Console.WriteLine();
        }

        private void ListarEmpleadosDetalladosUI()
        {
            Console.WriteLine("Lista de Empleados Detallados (con Sucursal):");
            Console.WriteLine("---------------------------------------------");
            var empleados = _uow.EmpleadoService.ObtenerSucursalDetallados();
            foreach (var e in empleados)
                Console.WriteLine($"{e.PersonaId} {e.Nombres} {e.ApellidoPat} {e.ApellidoMat} - " +
                                  $"Cargo: {e.Cargo}, Contratado: {e.FechaContratacion:dd/MM/yyyy}, " +
                                  $"DNI: {e.DocIdentidad}, Nac: {e.FechaNacimiento:dd/MM/yyyy}, " +
                                  $"Email: {e.Email}, Tel: {e.Telefono}, Dir: {e.Direccion}, " +
                                  $"{e.SucursalId}, {e.Sucursal.Nombre}, {e.Sucursal.Direccion}");
            Console.WriteLine();
        }
        private Empleado CapturarDatosEmpleado()
        {
            var empleado = new Empleado();
            Console.Write("Nombres: ");
            empleado.Nombres = Console.ReadLine();
            Console.Write("Apellido Paterno: ");
            empleado.ApellidoPat = Console.ReadLine();
            Console.Write("Apellido Materno: ");
            empleado.ApellidoMat = Console.ReadLine();
            Console.Write("Documento de Identidad: ");
            empleado.DocIdentidad = Console.ReadLine();
            Console.Write("Email: ");
            empleado.Email = Console.ReadLine();
            Console.Write("Telefono: ");
            empleado.Telefono = Console.ReadLine();
            Console.Write("Direccion: ");
            empleado.Direccion = Console.ReadLine();
            Console.Write("Cargo: ");
            empleado.Cargo = Console.ReadLine();
            return empleado;
        }
    }
}

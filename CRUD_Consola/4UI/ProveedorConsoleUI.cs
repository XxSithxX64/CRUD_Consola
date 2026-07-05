using CRUD_Consola._3Application.Services.Interfaces;
using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._4UI
{
    internal class ProveedorConsoleUI
    {
        private readonly IUnitOfWork _uow;

        public ProveedorConsoleUI(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== CRUD Proveedores ===");
                Console.WriteLine("1. Crear Proveedor");
                Console.WriteLine("2. Listar Proveedores");
                Console.WriteLine("3. Buscar Proveedor por ID");
                Console.WriteLine("4. Actualizar Proveedor");
                Console.WriteLine("5. Eliminar Proveedor");
                Console.WriteLine("0. Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();
                Console.WriteLine();
                switch (opcion)
                {
                    case "1": Console.Clear(); CrearProveedorUI(); break;
                    case "2": Console.Clear(); ListarProveedoresUI(); break;
                    case "3": Console.Clear(); BuscarProveedorUI(); break;
                    case "4": Console.Clear(); ActualizarProveedorUI(); break;
                    case "5": Console.Clear(); EliminarProveedorUI(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        private void CrearProveedorUI()
        {
            Console.WriteLine("Ingrese los datos del proveedor:");
            Console.WriteLine("--------------------------------");
            var proveedor = CapturarDatosProveedor();
            _uow.ProveedorService.CrearProveedor(proveedor);
            Console.WriteLine("✅ Proveedor registrado correctamente.");
            Console.WriteLine();
        }

        private void ListarProveedoresUI()
        {
            Console.WriteLine("Lista de Proveedores:");
            Console.WriteLine("---------------------");
            var proveedores = _uow.ProveedorService.ListarProveedores();
            foreach (var p in proveedores)
                Console.WriteLine(p.ToString());
            Console.WriteLine();
        }

        private void BuscarProveedorUI()
        {
            Console.WriteLine("Buscar proveedor a buscar: ");
            Console.WriteLine("---------------------------");
            Console.Write("Ingrese el ID del proveedor: ");
            var id = int.Parse(Console.ReadLine());
            var proveedor = _uow.ProveedorService.BuscarProveedor(id);
            if (proveedor != null)
                Console.WriteLine(proveedor.ToString());
            else
                Console.WriteLine("❌ Proveedor no encontrado.");
            Console.WriteLine();
        }

        private void ActualizarProveedorUI()
        {
            Console.WriteLine("Actualizar proveedor:");
            Console.WriteLine("---------------------");
            Console.Write("Ingrese el ID del proveedor a actualizar: ");
            var id = int.Parse(Console.ReadLine());
            var proveedor = _uow.ProveedorService.BuscarProveedor(id);
            if (proveedor == null)
            {
                Console.WriteLine("❌ Proveedor no encontrado.");
                return;
            }

            Console.WriteLine("Ingrese nuevos datos (dejar vacío para mantener el actual):");

            Console.Write($"Nombre ({proveedor.Nombre}): ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) proveedor.Nombre = nombre;

            Console.WriteLine($"Contacto ({proveedor.Contacto}): ");
            var contacto = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(contacto)) proveedor.Contacto = contacto;

            Console.WriteLine($"Teléfono ({proveedor.Telefono}): ");
            var telefono = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(telefono)) proveedor.Telefono = telefono;

            _uow.ProveedorService.ActualizarProveedor(proveedor);
            Console.WriteLine("✅ Proveedor actualizado correctamente.");
            Console.WriteLine();
        }

        private void EliminarProveedorUI()
        {
            Console.WriteLine("Eliminar proveedor:");
            Console.WriteLine("-------------------");
            Console.Write("Ingrese el ID del proveedor a eliminar: ");
            var id = int.Parse(Console.ReadLine());
            var proveedor = _uow.ProveedorService.BuscarProveedor(id);
            if (proveedor == null)
            {
                Console.WriteLine("❌ Proveedor no encontrado.");
                return;
            }
            _uow.ProveedorService.EliminarProveedor(id);
            Console.WriteLine("✅ Proveedor eliminado correctamente.");
            Console.WriteLine();
        }

        private Proveedor CapturarDatosProveedor()
        {
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();

            Console.Write("Contacto: ");
            var contacto = Console.ReadLine();

            Console.Write("Teléfono: ");
            var telefono = Console.ReadLine();

            return new Proveedor
            {
                Nombre = nombre,
                Contacto = contacto,
                Telefono = telefono
            };
        }
    }
}

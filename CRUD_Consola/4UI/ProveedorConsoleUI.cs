using CRUD_Consola._3Application.Services;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._4UI
{
    internal class ProveedorConsoleUI
    {
        private readonly ProveedorService _proveedorService;

        public ProveedorConsoleUI(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
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
            _proveedorService.CrearProveedor(proveedor);
            Console.WriteLine("✅ Proveedor registrado correctamente.");
        }

        private void ListarProveedoresUI()
        {
            Console.WriteLine("Lista de Proveedores:");
            Console.WriteLine("---------------------");
            var proveedores = _proveedorService.ListarProveedores();
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
            var proveedor = _proveedorService.BuscarProveedor(id);
            if (proveedor != null)
                Console.WriteLine(proveedor.ToString());
            else
                Console.WriteLine("❌ Proveedor no encontrado.");
        }

        private void ActualizarProveedorUI()
        {
            Console.WriteLine("Actualizar proveedor:");
            Console.WriteLine("---------------------");
            Console.Write("Ingrese el ID del proveedor a actualizar: ");
            var id = int.Parse(Console.ReadLine());
            var proveedor = _proveedorService.BuscarProveedor(id);
            if (proveedor == null)
            {
                Console.WriteLine("❌ Proveedor no encontrado.");
                return;
            }

            Console.WriteLine("ngrese nuevos datos (dejar vacío para mantener el actual):");

            Console.Write($"Nombre ({proveedor.Nombre}): ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) proveedor.Nombre = nombre;

            Console.WriteLine($"Contacto ({proveedor.Contacto}): ");
            var contacto = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(contacto)) proveedor.Contacto = contacto;

            Console.WriteLine($"Teléfono ({proveedor.Telefono}): ");
            var telefono = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(telefono)) proveedor.Telefono = telefono;

            _proveedorService.ActualizarProveedor(proveedor);
            Console.WriteLine("✅ Proveedor actualizado correctamente.");
        }

        private void EliminarProveedorUI()
        {
            Console.WriteLine("Eliminar proveedor:");
            Console.WriteLine("-------------------");
            Console.Write("Ingrese el ID del proveedor a eliminar: ");
            var id = int.Parse(Console.ReadLine());
            var proveedor = _proveedorService.BuscarProveedor(id);
            if (proveedor == null)
            {
                Console.WriteLine("❌ Proveedor no encontrado.");
                return;
            }
            _proveedorService.EliminarProveedor(id);
            Console.WriteLine("✅ Proveedor eliminado correctamente.");
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

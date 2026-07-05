using CRUD_Consola._3Application.Services.Interfaces;
using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._4UI
{
    internal class SucursalConsoleUI
    {
        private readonly IUnitOfWork _uow;

        public SucursalConsoleUI(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== CRUD Sucursales ===");
                Console.WriteLine("1. Crear Sucursal");
                Console.WriteLine("2. Listar Sucursales");
                Console.WriteLine("3. Buscar Sucursal por ID");
                Console.WriteLine("4. Actualizar Sucursal");
                Console.WriteLine("5. Eliminar Sucursal");
                Console.WriteLine("0. Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();
                Console.WriteLine();
                switch (opcion)
                {
                    case "1": Console.Clear(); CrearSucursalUI(); break;
                    case "2": Console.Clear(); ListarSucursalesUI(); break;
                    case "3": Console.Clear(); BuscarSucursalUI(); break;
                    case "4": Console.Clear(); ActualizarSucursalUI(); break;
                    case "5": Console.Clear(); EliminarSucursalUI(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        private void CrearSucursalUI()
        {
            Console.WriteLine("Ingrese los datos de la sucursal:");
            Console.WriteLine("---------------------------------");
            var sucursal = CapturarDatosSucursal();
            _uow.SucursalService.CrearSucursal(sucursal);
            Console.WriteLine("✅ Sucursal registrada correctamente.");
            Console.WriteLine();
        }

        private void ListarSucursalesUI()
        {
            Console.WriteLine("Lista de Sucursales:");
            Console.WriteLine("--------------------");
            var sucursales = _uow.SucursalService.ListarSucursales();
            foreach (var s in sucursales)
                Console.WriteLine(s.ToString());
            Console.WriteLine();
        }

        private void BuscarSucursalUI()
        {
            Console.WriteLine("Buscar Sucursal por ID:");
            Console.WriteLine("-----------------------");
            Console.Write("Ingrese el ID de la sucursal: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var sucursal = _uow.SucursalService.BuscarSucursal(id);
            if (sucursal != null)
                Console.WriteLine(sucursal.ToString());
            else
                Console.WriteLine("❌ Sucursal no encontrada.");
            Console.WriteLine();
        }

        private void ActualizarSucursalUI()
        {
            Console.WriteLine("Actualizar Sucursal:");
            Console.WriteLine("--------------------");
            Console.Write("Ingrese el ID de la sucursal a actualizar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var sucursal = _uow.SucursalService.BuscarSucursal(id);

            if (sucursal == null)
            {
                Console.WriteLine("❌ Sucursal no encontrada.");
                return;
            }

            Console.WriteLine("Ingrese nuevos datos (dejar vacío para mantener el actual):");

            Console.Write($"Nombre ({sucursal.Nombre}): ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) sucursal.Nombre = nombre;

            Console.WriteLine("$Dirección ({sucursal.Direccion}): ");
            var direccion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(direccion)) sucursal.Direccion = direccion;

            _uow.SucursalService.ActualizarSucursal(sucursal);
            Console.WriteLine("✅ Sucursal actualizada correctamente.");
            Console.WriteLine();
        }

        private void EliminarSucursalUI()
        {
            Console.WriteLine("Eliminar Sucursal:");
            Console.WriteLine("------------------");
            Console.Write("Ingrese el ID de la sucursal a eliminar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var sucursal = _uow.SucursalService.BuscarSucursal(id);
            if (sucursal == null)
            {
                Console.WriteLine("❌ Sucursal no encontrada.");
                return;
            }
            _uow.SucursalService.EliminarSucursal(id);
            Console.WriteLine("✅ Sucursal eliminada correctamente.");
        }

        private Sucursal CapturarDatosSucursal()
        {
            Console.Write("Nombre:");
            var nombre = Console.ReadLine();

            Console.Write("Dirección: ");
            var direccion = Console.ReadLine();

            return new Sucursal
            {
                Nombre = nombre,
                Direccion = direccion
            };
        }
    }
}

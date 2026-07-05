using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.UI;

namespace CRUD_Consola._4UI
{
    public class MenuConsoleUI
    {
        private readonly ClienteConsoleUI _clienteConsoleUI;
        private readonly SucursalConsoleUI _sucursalConsoleUI;
        private readonly ProveedorConsoleUI _proveedorConsoleUI;
        private readonly CategoriaConsoleUI _categoriaConsoleUI;
        private readonly ProductoConsoleUI _productoConsoleUI;
        private readonly EmpleadoConsoleUI _empleadoConsoleUI;

        public MenuConsoleUI(IUnitOfWork uow)
        {
            _clienteConsoleUI = new ClienteConsoleUI(uow);
            _sucursalConsoleUI = new SucursalConsoleUI(uow);
            _proveedorConsoleUI = new ProveedorConsoleUI(uow);
            _categoriaConsoleUI = new CategoriaConsoleUI(uow);
            _productoConsoleUI = new ProductoConsoleUI(uow);
            _empleadoConsoleUI = new EmpleadoConsoleUI(uow);
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. CRUD Clientes");
                Console.WriteLine("2. CRUD Sucursales");
                Console.WriteLine("3. CRUD Proveedores");
                Console.WriteLine("4. CRUD Categoria");
                Console.WriteLine("5. CRUD Producto");
                Console.WriteLine("6. CRUD Empleados");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear(); _clienteConsoleUI.MostrarMenu(); break;
                    case "2":
                        Console.Clear(); _sucursalConsoleUI.MostrarMenu(); break;
                    case "3":
                        Console.Clear(); _proveedorConsoleUI.MostrarMenu(); break;
                    case "4":
                        Console.Clear(); _categoriaConsoleUI.MostrarMenu(); break;
                    case "5":
                        Console.Clear(); _productoConsoleUI.MostrarMenu(); break;
                    case "6":
                        Console.Clear(); _empleadoConsoleUI.MostrarMenu(); break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("❌ Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}

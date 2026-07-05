using CRUD_Consola.UI;

namespace CRUD_Consola._4UI
{
    internal class MenuConsoleUI
    {
        private readonly ClienteConsoleUI _clienteConsoleUI;
        private readonly SucursalConsoleUI _sucursalConsoleUI;

        public MenuConsoleUI(ClienteConsoleUI clienteConsoleUI, SucursalConsoleUI sucursalConsoleUI)
        {
            _clienteConsoleUI = clienteConsoleUI;
            _sucursalConsoleUI = sucursalConsoleUI;
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
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        _clienteConsoleUI.MostrarMenu();
                        break;
                    case "2":
                        Console.Clear();
                        _sucursalConsoleUI.MostrarMenu();
                        break;
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

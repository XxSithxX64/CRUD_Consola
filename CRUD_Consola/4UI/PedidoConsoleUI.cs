
using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._4UI
{
    public class PedidoConsoleUI
    {
        private readonly IUnitOfWork _uow;

        public PedidoConsoleUI(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== CRUD Pedidos ===");
                Console.WriteLine("1. Crear Pedido");
                Console.WriteLine("2. Listar Pedidos");
                Console.WriteLine("3. Buscar Pedido por ID");
                Console.WriteLine("4. Actualizar Pedido (No disponible)");
                Console.WriteLine("5. Eliminar Pedido");
                Console.WriteLine("6. Listar Pedidos Detallados (con Cliente y Producto)");
                Console.WriteLine("0. Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1": Console.Clear(); CrearPedidoUI(); break;
                    case "2": Console.Clear(); ListarPedidosUI(); break;
                    case "3": Console.Clear(); BuscarPedidoUI(); break;
                    case "4": Console.Clear(); /**ActualizarPedidoUI()**/; break;
                    case "5": Console.Clear(); EliminarPedidoUI(); break;
                    case "6": Console.Clear(); MostrarPedidosDetallados(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        private void CrearPedidoUI()
        {
            Console.Clear();
            Console.WriteLine("Ingrese los datos del pedido:");
            Console.WriteLine("-----------------------------");
            var pedido = CapturarDatosPedido();
            _uow.PedidoService.Crear(pedido);
            _uow.SaveChanges();
            Console.WriteLine("✅ Pedido registrado correctamente.");
            Console.WriteLine();
        }

        private void ListarPedidosUI()
        {
            Console.Clear();
            Console.WriteLine("Lista de Pedidos:");
            Console.WriteLine("-----------------");
            var pedidos = _uow.PedidoService.Listar();
            foreach (var p in pedidos)
                Console.WriteLine(p.ToString());
            Console.WriteLine();
        }

        public void BuscarPedidoUI()
        {
            Console.Clear();
            Console.WriteLine("Buscar Pedido por ID:");
            Console.WriteLine("---------------------");
            Console.Write("Ingrese el ID del pedido a buscar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var producto = _uow.PedidoService.Buscar(id);
            if(producto != null)
                Console.WriteLine(producto.ToString());
            else 
                Console.WriteLine("❌ Pedido no encontrado.");
            Console.WriteLine();
        }

        private void ActualizarPedidoUI()
        {
            Console.Clear();
            Console.WriteLine("Actualizar Pedido:");
            Console.WriteLine("------------------");
            Console.Write("Ingrese el ID del pedido a actualizar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var pedido = _uow.PedidoService.Buscar(id);
            if (pedido == null)
            {
                Console.WriteLine("❌ Pedido no encontrado.");
                return;
            }
            
            Console.WriteLine("Ingrese nuevos datos (dejar vacío para mantener el actual):");


            _uow.PedidoService.Actualizar(pedido);
            _uow.SaveChanges();
            Console.WriteLine("✅ Pedido actualizado correctamente.");
            Console.WriteLine();
        }

        private void EliminarPedidoUI() 
        {
            Console.Clear();
            Console.WriteLine("Eliminar Pedido:");
            Console.WriteLine("----------------");
            Console.WriteLine("Ingrese el ID del pedido a eliminar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var pedido = _uow.PedidoService.Buscar(id);
            if(pedido == null)
            {
                Console.WriteLine("❌ Pedido no encontrado.");
                return;
            }
            _uow.PedidoService.Eliminar(id);
            _uow.SaveChanges();
            Console.WriteLine("✅ Producto eliminado correctamente.");
        }

        public void MostrarPedidosDetallados()
        {
            Console.Clear();
            var pedido = _uow.PedidoService.ObtenerPedidosDetallados();

            Console.WriteLine("=== Lista de Pedido con Cliente y Empleado ===");
            foreach (var p in pedido)
            {
                Console.WriteLine($"{p.PedidoId}, {p.Cliente.Nombres}, {p.Empleado.Nombres}, {p.Fecha}");
            }
            Console.WriteLine();
        }

        private Pedido CapturarDatosPedido()
        {
            var pedido = new Pedido();
            pedido.Fecha = DateTime.Now;
            Console.Write("codigo de Cliente: ");
            pedido.ClienteId = Convert.ToInt32(Console.ReadLine());
            Console.Write("codigo de Empleado: ");
            pedido.EmpleadoId = Convert.ToInt32(Console.ReadLine());

            return pedido;
        }
    }
}

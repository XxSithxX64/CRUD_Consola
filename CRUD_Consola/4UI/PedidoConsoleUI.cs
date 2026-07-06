
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
                Console.WriteLine("7. Listar Pedidos por Cliente");
                Console.WriteLine("8. Listar Pedidos por Empleado");
                Console.WriteLine("9. Listar Pedidos por Sucursal");
                Console.WriteLine("10. Listar Pedidos por Fecha");
                Console.WriteLine("11. Mostrar Pedido Completo");
                Console.WriteLine("12. Calcular Total Pedido");
                Console.WriteLine("13. Verificar Stock");
                Console.WriteLine("14. Actualizar Stock después de Pedido");
                Console.WriteLine("15. Resumen de Ventas por Categoría");
                Console.WriteLine("16. Generar Factura desde Pedido");
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
                    case "6": Console.Clear(); GetPedidosConClienteYEmpleado(); break;
                    case "7": Console.Clear(); ListarPorClienteUI(); break;
                    case "8": Console.Clear(); ListarPorEmpleadoUI(); break;
                    case "9": Console.Clear(); ListarPorSucursalUI(); break;
                    case "10": Console.Clear(); ListarPorFechaUI(); break;
                    case "11": Console.Clear(); MostrarPedidoCompletoUI(); break;
                    case "12": Console.Clear(); CalcularTotalUI(); break;
                    case "13": Console.Clear(); VerificarStockUI(); break;
                    case "14": Console.Clear(); ActualizarStockUI(); break;
                    case "15": Console.Clear(); ResumenVentasUI(); break;
                    case "16": Console.Clear(); GenerarFacturaUI(); break;
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

        public void GetPedidosConClienteYEmpleado()
        {
            Console.Clear();
            var pedido = _uow.PedidoService.GetPedidosConClienteYEmpleado();

            Console.WriteLine("=== Lista de Pedido con Cliente y Empleado ===");
            foreach (var p in pedido)
            {
                Console.WriteLine($"{p.PedidoId}, {p.Cliente.Nombres}, {p.Empleado.Nombres}, {p.Fecha}");
            }
            Console.WriteLine();
        }

        private void ListarPorClienteUI()
        {
            Console.Write("ClienteId: ");
            var clienteId = Convert.ToInt32(Console.ReadLine());
            var pedidos = _uow.PedidoService.GetPedidosPorCliente(clienteId);
            foreach (var p in pedidos)
                Console.WriteLine($"{p.PedidoId} - {p.Cliente.Nombres} - {p.Fecha}");
        }

        private void ListarPorEmpleadoUI()
        {
            Console.Write("EmpleadoId: ");
            var empleadoId = Convert.ToInt32(Console.ReadLine());
            var pedidos = _uow.PedidoService.GetPedidosPorEmpleado(empleadoId);
            foreach (var p in pedidos)
                Console.WriteLine($"{p.PedidoId} - {p.Empleado.Nombres} - {p.Fecha}");
        }

        private void ListarPorSucursalUI()
        {
            Console.Write("SucursalId: ");
            var sucursalId = Convert.ToInt32(Console.ReadLine());
            var pedidos = _uow.PedidoService.GetPedidosPorSucursal(sucursalId);
            foreach (var p in pedidos)
                Console.WriteLine($"{p.PedidoId} - {p.Empleado.Nombres} - {p.Fecha}");
        }

        private void ListarPorFechaUI()
        {
            Console.Write("Fecha inicio (yyyy-MM-dd): ");
            var inicio = DateTime.Parse(Console.ReadLine());
            Console.Write("Fecha fin (yyyy-MM-dd): ");
            var fin = DateTime.Parse(Console.ReadLine());

            var pedidos = _uow.PedidoService.GetPedidosPorFecha(inicio, fin);
            foreach (var p in pedidos)
                Console.WriteLine($"{p.PedidoId} - {p.Cliente.Nombres} - {p.Fecha}");
        }

        private void MostrarPedidoCompletoUI()
        {
            Console.Write("PedidoId: ");
            var pedidoId = Convert.ToInt32(Console.ReadLine());
            var pedido = _uow.PedidoService.GetPedidoCompleto(pedidoId);

            if (pedido == null)
            {
                Console.WriteLine("❌ Pedido no encontrado.");
                return;
            }

            Console.WriteLine($"Pedido {pedido.PedidoId} - Cliente: {pedido.Cliente.Nombres} - Empleado: {pedido.Empleado.Nombres}");
            foreach (var d in pedido.Detalles)
                Console.WriteLine($"{d.Producto.Nombre} x{d.Cantidad} = {(d.Cantidad * d.PrecioUnitario):C2}");
            Console.WriteLine($"Total: {pedido.Factura?.MontoTotal ?? 0:C2}");
        }

        private void CalcularTotalUI()
        {
            Console.Write("PedidoId: ");
            var pedidoId = Convert.ToInt32(Console.ReadLine());
            var total = _uow.PedidoService.CalcularTotalPedido(pedidoId);
            Console.WriteLine($"Total del pedido: {total:C2}");
        }

        private void VerificarStockUI()
        {
            Console.Write("PedidoId: ");
            var pedidoId = Convert.ToInt32(Console.ReadLine());
            var ok = _uow.PedidoService.VerificarStock(pedidoId);
            Console.WriteLine(ok ? "✅ Stock suficiente." : "❌ Stock insuficiente.");
        }

        private void ActualizarStockUI()
        {
            Console.Write("PedidoId: ");
            var pedidoId = Convert.ToInt32(Console.ReadLine());
            _uow.PedidoService.ActualizarStockDespuesDePedido(pedidoId);
            _uow.SaveChanges();
            Console.WriteLine("✅ Stock actualizado.");
        }

        private void ResumenVentasUI()
        {
            var resumen = _uow.PedidoService.GetResumenVentasPorCategoria();
            Console.WriteLine("=== Resumen de Ventas por Categoría ===");
            foreach (var r in resumen)
                Console.WriteLine($"{r}");
        }

        private void GenerarFacturaUI()
        {
            Console.Write("PedidoId: ");
            var pedidoId = Convert.ToInt32(Console.ReadLine());
            var factura = _uow.PedidoService.GenerarFacturaDesdePedido(pedidoId);

            if (factura == null)
                Console.WriteLine("❌ No se pudo generar la factura.");
            else
                Console.WriteLine($"✅ Factura {factura.FacturaId} generada con total {factura.MontoTotal:C2}");
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

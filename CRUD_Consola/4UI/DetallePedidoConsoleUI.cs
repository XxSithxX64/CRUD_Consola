using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._4UI
{
    internal class DetallePedidoConsoleUI
    {
        private readonly IUnitOfWork _uow;

        public DetallePedidoConsoleUI(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (salir)
            {
                Console.WriteLine("=== CRUD Detalle-Pedido ===");
                Console.WriteLine("1. Crear DetallePedido");
                Console.WriteLine("3. Buscar DetallePedido por ID");
                Console.WriteLine("4. Actualizar DetallePedido");
                Console.WriteLine("5. Eliminar DetallePedido");
                Console.WriteLine("6. Listar DetallePedidos Detallados (con Categoría y Proveedor)");
                Console.WriteLine("0. Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();
                Console.WriteLine();
                switch (opcion)
                {
                    case "1": Console.Clear(); CrearDetallePedidoUI(); break;
                    case "2": Console.Clear(); ListarDetallePedidosUI(); break;
                    case "3": Console.Clear(); BuscarDetallePedidoUI(); break;
                    case "4": Console.Clear(); ActualizarDetallePedidoUI(); break;
                    case "5": Console.Clear(); EliminarDetallePedidoUI(); break;
                    case "6": Console.Clear(); MostrarPedidosDetallados(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        private void CrearDetallePedidoUI()
        {
            Console.Clear();
            Console.WriteLine("Ingrese los datos del DetallePedido:");
            Console.WriteLine("-------------------------------");
            var DetallePedido = CapturarDatosDetallePedido();
            _uow.DetallePedidoService.Crear(DetallePedido);
            _uow.SaveChanges();
            Console.WriteLine("✅ DetallePedido registrado correctamente.");
            Console.WriteLine();
        }

        private void ListarDetallePedidosUI()
        {
            Console.Clear();
            Console.WriteLine("Lista de DetallePedidos:");
            Console.WriteLine("-------------------");
            var DetallePedidos = _uow.DetallePedidoService.Listar();
            foreach (var p in DetallePedidos)
                Console.WriteLine(p.ToString());
            Console.WriteLine();
        }

        public void BuscarDetallePedidoUI()
        {
            Console.Clear();
            Console.WriteLine("Buscar DetallePedido por ID:");
            Console.WriteLine("-----------------------");
            Console.Write("Ingrese el ID del DetallePedido: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var DetallePedido = _uow.DetallePedidoService.Buscar(id);
            if (DetallePedido != null)
                Console.WriteLine(DetallePedido.ToString());
            else
                Console.WriteLine("❌ DetallePedido no encontrado.");
            Console.WriteLine();
        }

        private void ActualizarDetallePedidoUI()
        {
            Console.Clear();
            Console.WriteLine("Actualizar DetallePedido:");
            Console.WriteLine("--------------------");
            Console.Write("Ingrese el ID del DetallePedido a actualizar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var DetallePedido = _uow.DetallePedidoService.Buscar(id);

            if (DetallePedido == null)
            {
                Console.WriteLine("❌ DetallePedido no encontrado.");
                return;
            }

            Console.WriteLine("Ingrese nuevos datos (dejar vacío para mantener el actual):");

            Console.WriteLine($"Cantidad ({DetallePedido.Cantidad}): ");
            var cantidad = Convert.ToInt32(Console.ReadLine());
            if (!string.IsNullOrWhiteSpace(cantidad.ToString())) DetallePedido.Cantidad = cantidad;

            Console.WriteLine($"Precio Unitario ({DetallePedido.PrecioUnitario}): ");
            var precioUnitario = Convert.ToInt32(Console.ReadLine());
            if (!string.IsNullOrWhiteSpace(precioUnitario.ToString())) DetallePedido.PrecioUnitario = precioUnitario;

            _uow.DetallePedidoService.Actualizar(DetallePedido);
            _uow.SaveChanges();
            Console.WriteLine("✅ DetallePedido actualizado correctamente.");
            Console.WriteLine();
        }

        private void EliminarDetallePedidoUI()
        {
            Console.Clear();
            Console.WriteLine("Eliminar DetallePedido:");
            Console.WriteLine("------------------");
            Console.Write("Ingrese el ID del DetallePedido a eliminar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var DetallePedido = _uow.DetallePedidoService.Buscar(id);
            if (DetallePedido == null)
            {
                Console.WriteLine("❌ DetallePedido no encontrado.");
                return;
            }
            _uow.DetallePedidoService.Eliminar(id);
            _uow.SaveChanges();
            Console.WriteLine("✅ DetallePedido eliminado correctamente.");
        }

        public void MostrarPedidosDetallados()
        {
            Console.Clear();
            var DetallePedidos = _uow.DetallePedidoService.ObtenerDetallePedidoDetallado();

            Console.WriteLine("=== Lista de DetallePedidos con Categoría y Proveedor ===");
            foreach (var d in DetallePedidos)
            {
                Console.WriteLine(
                    $"DetalleId: {d.DetalleId}, " +
                    $"Producto: {d.Producto?.Nombre}, " +
                    $"Categoría: {d.Producto?.Categoria?.Nombre}, " +
                    $"Proveedor: {d.Producto?.Proveedor?.Nombre}, " +
                    $"Cantidad: {d.Cantidad}, PrecioUnitario: {d.PrecioUnitario:C}, " +
                    $"PedidoId: {d.PedidoId}, FechaPedido: {d.Pedido?.Fecha:dd/MM/yyyy}, " +
                    $"Cliente: {d.Pedido?.Cliente?.Nombres} {d.Pedido?.Cliente?.ApellidoPat}, " +
                    $"Empleado: {d.Pedido?.Empleado?.Nombres} {d.Pedido?.Empleado?.ApellidoPat}, " +
                    $"Sucursal: {d.Pedido?.Empleado?.Sucursal?.Nombre}"
                    );
            }
            Console.WriteLine();
        }

        private DetallePedido CapturarDatosDetallePedido()
        {
            var detalles = new DetallePedido();
            Console.Write("Codigo del Pedido: ");
            detalles.PedidoId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Codigo del Producto: ");
            detalles.ProductoId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Cantidad: ");
            detalles.Cantidad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Precio Unitario ");
            detalles.PrecioUnitario = Convert.ToDecimal(Console.ReadLine());
            return detalles;
        }
    }
}

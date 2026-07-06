using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._4UI
{
    public class PagoConsoleUI
    {
        private readonly IUnitOfWork _uow;

        public PagoConsoleUI(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== CRUD Pagos ===");
                Console.WriteLine("1. Crear Pago");
                Console.WriteLine("2. Listar Pagos");
                Console.WriteLine("3. Buscar Pago por ID");
                Console.WriteLine("4. Actualizar Pago");
                Console.WriteLine("5. Eliminar Pago");
                Console.WriteLine("6. Listar Pagos por Factura");
                Console.WriteLine("7. Listar Pagos por Fecha");
                Console.WriteLine("8. Listar Pagos por Método");
                Console.WriteLine("9. Mostrar Total Pagado por Factura");
                Console.WriteLine("10. Mostrar Pendiente por Factura");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1": CrearPagoUI(); break;
                    case "2": ListarPagosUI(); break;
                    case "3": BuscarPagoUI(); break;
                    case "4": ActualizarPagoUI(); break;
                    case "5": EliminarPagoUI(); break;
                    case "6": ListarPorFacturaUI(); break;
                    case "7": ListarPorFechaUI(); break;
                    case "8": ListarPorMetodoUI(); break;
                    case "9": MostrarTotalPagadoUI(); break;
                    case "10": MostrarPendienteUI(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        // 🔹 1. Crear
        private void CrearPagoUI()
        {
            var pago = CapturarDatosPago();
            _uow.PagoService.Crear(pago);
            _uow.SaveChanges();
            Console.WriteLine("✅ Pago registrado correctamente.");
        }

        // 🔹 2. Listar
        private void ListarPagosUI()
        {
            var pagos = _uow.PagoService.Listar();
            Console.WriteLine("=== Lista de Pagos ===");
            foreach (var p in pagos)
                Console.WriteLine(p.ToString());
        }

        // 🔹 3. Buscar por ID
        private void BuscarPagoUI()
        {
            Console.Write("Ingrese el ID del pago: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var pago = _uow.PagoService.Buscar(id);
            Console.WriteLine(pago != null ? pago.ToString() : "❌ Pago no encontrado.");
        }

        // 🔹 4. Actualizar
        private void ActualizarPagoUI()
        {
            Console.Write("Ingrese el ID del pago a actualizar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var pago = _uow.PagoService.Buscar(id);

            if (pago == null)
            {
                Console.WriteLine("❌ Pago no encontrado.");
                return;
            }

            Console.WriteLine($"Monto actual ({pago.Monto}): ");
            var montoStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(montoStr))
                pago.Monto = Convert.ToDecimal(montoStr);

            Console.WriteLine($"Método actual ({pago.MetodoPago}): ");
            var metodo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(metodo))
                pago.MetodoPago = metodo;

            _uow.PagoService.Actualizar(pago);
            _uow.SaveChanges();
            Console.WriteLine("✅ Pago actualizado correctamente.");
        }

        // 🔹 5. Eliminar
        private void EliminarPagoUI()
        {
            Console.Write("Ingrese el ID del pago a eliminar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var pago = _uow.PagoService.Buscar(id);

            if (pago == null)
            {
                Console.WriteLine("❌ Pago no encontrado.");
                return;
            }

            _uow.PagoService.Eliminar(id);
            _uow.SaveChanges();
            Console.WriteLine("✅ Pago eliminado correctamente.");
        }

        // 🔹 6. Listar por Factura
        private void ListarPorFacturaUI()
        {
            Console.Write("Ingrese el ID de la factura: ");
            var facturaId = Convert.ToInt32(Console.ReadLine());
            var pagos = _uow.PagoService.GetByFactura(facturaId);
            foreach (var p in pagos)
                Console.WriteLine(p.ToString());
        }

        // 🔹 7. Listar por Fecha
        private void ListarPorFechaUI()
        {
            Console.Write("Fecha inicio (yyyy-MM-dd): ");
            var inicio = DateTime.Parse(Console.ReadLine());
            Console.Write("Fecha fin (yyyy-MM-dd): ");
            var fin = DateTime.Parse(Console.ReadLine());

            var pagos = _uow.PagoService.GetByFecha(inicio, fin);
            foreach (var p in pagos)
                Console.WriteLine(p.ToString());
        }

        // 🔹 8. Listar por Método
        private void ListarPorMetodoUI()
        {
            Console.Write("Ingrese el método de pago: ");
            var metodo = Console.ReadLine();
            var pagos = _uow.PagoService.GetByMetodo(metodo);
            foreach (var p in pagos)
                Console.WriteLine(p.ToString());
        }

        // 🔹 9. Total Pagado por Factura
        private void MostrarTotalPagadoUI()
        {
            Console.Write("Ingrese el ID de la factura: ");
            var facturaId = Convert.ToInt32(Console.ReadLine());
            var total = _uow.PagoService.GetTotalPagadoPorFactura(facturaId);
            Console.WriteLine($"Total pagado: {total:C2}");
        }

        // 🔹 10. Pendiente por Factura
        private void MostrarPendienteUI()
        {
            Console.Write("Ingrese el ID de la factura: ");
            var facturaId = Convert.ToInt32(Console.ReadLine());
            var pendiente = _uow.PagoService.GetPendientePorFactura(facturaId);
            Console.WriteLine($"Monto pendiente: {pendiente:C2}");
        }

        // 🔹 Función para capturar datos de pago
        private Pago CapturarDatosPago()
        {
            Console.Write("FacturaId: ");
            var facturaId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Monto: ");
            var monto = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Método de pago (Efectivo/Tarjeta/Transferencia): ");
            var metodo = Console.ReadLine();

            return new Pago
            {
                FacturaId = facturaId,
                FechaPago = DateTime.Now,
                Monto = monto,
                MetodoPago = metodo
            };
        }
    }
}

using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Consola._4UI
{
    internal class FacturaConsoleUI
    {
        private readonly IUnitOfWork _uow;

        public FacturaConsoleUI(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== CRUD Facturas ===");
                Console.WriteLine("1. Crear Factura");
                Console.WriteLine("2. Listar Facturas");
                Console.WriteLine("3. Buscar Factura por ID");
                Console.WriteLine("4. Actualizar Factura");
                Console.WriteLine("5. Eliminar Factura");
                Console.WriteLine("6. Buscar Factura por Pedido");
                Console.WriteLine("7. Listar Facturas por Cliente");
                Console.WriteLine("8. Listar Facturas por Fecha");
                Console.WriteLine("9. Mostrar Boleta Completa (Factura + Pedido + Detalles)");
                Console.WriteLine("10. Mostrar Factura con Pagos");
                Console.WriteLine("0. Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1": Console.Clear(); CrearFacturaUI(); break;
                    case "2": Console.Clear(); ListarFacturasUI(); break;
                    case "3": Console.Clear(); BuscarFacturaUI(); break;
                    case "4": Console.Clear(); ActualizarFacturaUI(); break;
                    case "5": Console.Clear(); EliminarFacturaUI(); break;
                    case "6": Console.Clear(); BuscarPorPedidoUI(); break;
                    case "7": Console.Clear(); ListarPorClienteUI(); break;
                    case "8": Console.Clear(); ListarPorFechaUI(); break;
                    case "9": Console.Clear(); MostrarBoletaCompletaUI(); break;
                    case "10": Console.Clear(); MostrarFacturaConPagosUI(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        private void CrearFacturaUI()
        {
            Console.WriteLine("Ingrese los datos de la factura:");
            var factura = CapturarDatosFactura();
            _uow.FacturaService.Crear(factura);
            _uow.SaveChanges();
            Console.WriteLine("✅ Factura registrada correctamente.");
        }
        private void ListarFacturasUI()
        {
            var facturas = _uow.FacturaService.Listar();
            Console.WriteLine("=== Lista de Facturas ===");
            foreach (var f in facturas)
                Console.WriteLine(f.ToString());
        }

        private void BuscarFacturaUI()
        {
            Console.Write("Ingrese el ID de la factura: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var factura = _uow.FacturaService.Buscar(id);
            Console.WriteLine(factura != null ? factura.ToString() : "❌ Factura no encontrada.");
        }

        private void ActualizarFacturaUI()
        {
            Console.Write("Ingrese el ID de la factura a actualizar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var factura = _uow.FacturaService.Buscar(id);

            if (factura == null)
            {
                Console.WriteLine("❌ Factura no encontrada.");
                return;
            }

            Console.WriteLine($"Monto Total actual ({factura.MontoTotal}): ");
            var montoStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(montoStr))
                factura.MontoTotal = Convert.ToDecimal(montoStr);

            _uow.FacturaService.Actualizar(factura);
            _uow.SaveChanges();
            Console.WriteLine("✅ Factura actualizada correctamente.");
        }

        private void EliminarFacturaUI()
        {
            Console.Write("Ingrese el ID de la factura a eliminar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var factura = _uow.FacturaService.Buscar(id);

            if (factura == null)
            {
                Console.WriteLine("❌ Factura no encontrada.");
                return;
            }

            _uow.FacturaService.Eliminar(id);
            _uow.SaveChanges();
            Console.WriteLine("✅ Factura eliminada correctamente.");
        }

        private void BuscarPorPedidoUI()
        {
            Console.Write("Ingrese el ID del pedido: ");
            var pedidoId = Convert.ToInt32(Console.ReadLine());
            var factura = _uow.FacturaService.GetByPedido(pedidoId);
            Console.WriteLine(factura != null ? factura.ToString() : "❌ No existe factura para ese pedido.");
        }

        private void ListarPorClienteUI()
        {
            Console.Write("Ingrese el ID del cliente: ");
            var clienteId = Convert.ToInt32(Console.ReadLine());
            var facturas = _uow.FacturaService.GetByCliente(clienteId);
            foreach (var f in facturas)
                Console.WriteLine(f.ToString());
        }

        private void ListarPorFechaUI()
        {
            Console.Write("Fecha inicio (yyyy-MM-dd): ");
            var inicio = DateTime.Parse(Console.ReadLine());
            Console.Write("Fecha fin (yyyy-MM-dd): ");
            var fin = DateTime.Parse(Console.ReadLine());

            var facturas = _uow.FacturaService.GetByFecha(inicio, fin);
            foreach (var f in facturas)
                Console.WriteLine(f.ToString());
        }

        private void MostrarBoletaCompletaUI()
        {
            Console.Write("Ingrese el ID de la factura: ");
            var facturaId = Convert.ToInt32(Console.ReadLine());
            var factura = _uow.FacturaService.GetBoletaCompleta(facturaId);

            if (factura == null)
            {
                Console.WriteLine("❌ Factura no encontrada.");
                return;
            }

            Console.WriteLine($"Factura {factura.FacturaId} - Fecha: {factura.FechaEmision:dd/MM/yyyy}");
            Console.WriteLine($"Cliente: {factura.Pedido.Cliente.Nombres}, Empleado: {factura.Pedido.Empleado.Nombres}");
            Console.WriteLine("=== Detalles ===");

            foreach (var d in factura.Pedido.Detalles)
            {
                Console.WriteLine($"{d.Producto.Nombre} x{d.Cantidad} = {(d.Cantidad * d.PrecioUnitario):C2}");
            }

            // ✅ Aquí usas el campo MontoTotal de la tabla Factura
            Console.WriteLine($"Monto Total (Factura): {factura.MontoTotal:C2}");
        }


        private void MostrarFacturaConPagosUI()
        {
            Console.Write("Ingrese el ID de la factura: ");
            var facturaId = Convert.ToInt32(Console.ReadLine());
            var factura = _uow.FacturaService.GetWithPagos(facturaId);

            if (factura == null)
            {
                Console.WriteLine("❌ Factura no encontrada.");
                return;
            }

            Console.WriteLine($"Factura {factura.FacturaId} - Total: {factura.MontoTotal:C}");
            Console.WriteLine("=== Pagos ===");
            foreach (var pago in factura.Pagos)
                Console.WriteLine($"Pago {pago.PagoId} - Fecha: {pago.FechaPago:dd/MM/yyyy} - Monto: {pago.Monto:C}");
        }

        private Factura CapturarDatosFactura()
        {
            Console.Write("PedidoId: ");
            var pedidoId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Monto Total: ");
            var monto = Convert.ToDecimal(Console.ReadLine());

            return new Factura
            {
                PedidoId = pedidoId,
                FechaEmision = DateTime.Now,
                MontoTotal = monto
            };
        }
    }
}

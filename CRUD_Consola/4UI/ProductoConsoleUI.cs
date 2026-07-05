using CRUD_Consola._3Application.Services.Interfaces;
using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._4UI
{
    internal class ProductoConsoleUI
    {
        private readonly IUnitOfWork _uow;

        public ProductoConsoleUI(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== CRUD Productos ===");
                Console.WriteLine("1. Crear Producto");
                Console.WriteLine("2. Listar Productos");
                Console.WriteLine("3. Buscar Producto por ID");
                Console.WriteLine("4. Actualizar Producto");
                Console.WriteLine("5. Eliminar Producto");
                Console.WriteLine("0. Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();
                Console.WriteLine();
                switch (opcion)
                {
                    case "1": Console.Clear(); CrearProductoUI(); break;
                    case "2": Console.Clear(); ListarProductosUI(); break;
                    case "3": Console.Clear(); BuscarProductoUI(); break;
                    case "4": Console.Clear(); ActualizarProductoUI(); break;
                    case "5": Console.Clear(); EliminarProductoUI(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        private void CrearProductoUI() 
        { 
            Console.WriteLine("Ingrese los datos del producto:");
            Console.WriteLine("-------------------------------");
            var producto = CapturarDatosProducto();
            _uow.ProductoService.CrearProducto(producto);
            Console.WriteLine("✅ Producto registrado correctamente.");
            Console.WriteLine();
        }

        private void ListarProductosUI()
        {
            Console.WriteLine("Lista de Productos:");
            Console.WriteLine("-------------------");
            var productos = _uow.ProductoService.ListarProductos();
            foreach (var p in productos)
                Console.WriteLine(p.ToString());
            Console.WriteLine();
        }

        public void BuscarProductoUI()
        {
            Console.WriteLine("Buscar Producto por ID:");
            Console.WriteLine("-----------------------");
            Console.Write("Ingrese el ID del producto: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var producto = _uow.ProductoService.BuscarProducto(id);
            if(producto != null)
                Console.WriteLine(producto.ToString());
            else
                Console.WriteLine("❌ Producto no encontrado.");
            Console.WriteLine();
        }

        private void ActualizarProductoUI()
        {
            Console.WriteLine("Actualizar Producto:");
            Console.WriteLine("--------------------");
            Console.Write("Ingrese el ID del producto a actualizar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var producto= _uow.ProductoService.BuscarProducto(id);
            
            if(producto== null)
            {
                Console.WriteLine("❌ Producto no encontrado.");
                return;
            }

            Console.WriteLine("Ingrese nuevos datos (dejar vacío para mantener el actual):");
            
            Console.WriteLine($"Nombre ({producto.Nombre}): ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) producto.Nombre = nombre;

            Console.WriteLine($"Precio ({producto.Precio}): ");
            decimal precio = decimal.Parse(Console.ReadLine());
            if (!string.IsNullOrWhiteSpace(precio.ToString())) producto.Precio = precio;
            
            Console.WriteLine($"Stock ({producto.Stock}): ");
            var stock = Convert.ToInt32(Console.ReadLine());
            if(!string.IsNullOrWhiteSpace(stock.ToString())) producto.Stock = stock;

            // Mostrar categorías
            Console.WriteLine("=== Categorías disponibles ===");
            foreach (var categoria in _uow.CategoriaService.ListarCategorias())
            {
                Console.WriteLine($"{categoria.CategoriaId} - {categoria.Nombre}");
            }
            Console.WriteLine($"CategoriaId ({producto.CategoriaId}): ");
            var categoriaId = Convert.ToInt32(Console.ReadLine());
            if(!string.IsNullOrWhiteSpace(categoriaId.ToString())) producto.CategoriaId = categoriaId;

            // Mostrar proveedores
            Console.WriteLine("=== Proveedores disponibles ===");
            foreach (var proveedor in _uow.ProveedorService.ListarProveedores())
            {
                Console.WriteLine($"{proveedor.ProveedorId} - {proveedor.Nombre} ({proveedor.Contacto})");
            }
            Console.WriteLine($"ProveedorId ({producto.ProveedorId}): ");
            var proveedorId = Convert.ToInt32(Console.ReadLine());
            if(!string.IsNullOrWhiteSpace(proveedorId.ToString())) producto.ProveedorId = proveedorId;

            _uow.ProductoService.ActualizarProducto(producto);
            Console.WriteLine("✅ Producto actualizado correctamente.");
            Console.WriteLine();
        }

        private void EliminarProductoUI()
        {
            Console.WriteLine("Eliminar Producto:");
            Console.WriteLine("------------------");
            Console.Write("Ingrese el ID del producto a eliminar: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var producto = _uow.ProductoService.BuscarProducto(id);
            if (producto == null)
            {
                Console.WriteLine("❌ Producto no encontrado.");
                return;
            }
            _uow.ProductoService.EliminarProducto(id);
            Console.WriteLine("✅ Producto eliminado correctamente.");
        }

        private Producto CapturarDatosProducto()
        {
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();

            Console.Write("Precio: ");
            var precio = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Stock: ");
            var stock = Convert.ToInt32(Console.ReadLine());

            // Mostrar categorías
            Console.WriteLine("=== Categorías disponibles ===");
            foreach (var categoria in _uow.CategoriaService.ListarCategorias())
            {
                Console.WriteLine($"{categoria.CategoriaId} - {categoria.Nombre}");
            }
            Console.Write("CategoriaId: ");
            var categoriaId = Convert.ToInt32(Console.ReadLine());

            // Mostrar proveedores
            Console.WriteLine("=== Proveedores disponibles ===");
            foreach (var proveedor in _uow.ProveedorService.ListarProveedores())
            {
                Console.WriteLine($"{proveedor.ProveedorId} - {proveedor.Nombre} ({proveedor.Contacto})");
            }
            Console.Write("ProveedorId: ");
            var proveedorId = Convert.ToInt32(Console.ReadLine());

            return new Producto
            {
                Nombre = nombre,
                Precio = precio,
                Stock = stock,
                CategoriaId = categoriaId,
                ProveedorId = proveedorId
            };
        }
    }
}

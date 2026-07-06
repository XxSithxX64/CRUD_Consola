using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._4UI
{
    public class CategoriaConsoleUI
    {
        private readonly IUnitOfWork _uow;

        public CategoriaConsoleUI(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== CRUD Categorías ===");
                Console.WriteLine("1. Crear Categoría");
                Console.WriteLine("2. Listar Categorías");
                Console.WriteLine("3. Buscar Categoría por ID");
                Console.WriteLine("4. Actualizar Categoría");
                Console.WriteLine("5. Eliminar Categoría");
                Console.WriteLine("0. Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();
                Console.WriteLine();
                switch (opcion)
                {
                    case "1": Console.Clear(); CrearCategoriaUI(); break;
                    case "2": Console.Clear(); ListarCategoriasUI(); break;
                    case "3": Console.Clear(); BuscarCategoriaUI(); break;
                    case "4": Console.Clear(); ActualizarCategoriaUI(); break;
                    case "5": Console.Clear(); EliminarCategoriaUI(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        public void CrearCategoriaUI()
        {
            Console.WriteLine("Ingrese los datos de la categoría:");
            Console.WriteLine("----------------------------------");
            var categoria = CapturarDatosCategoria();
            _uow.CategoriaService.Crear(categoria);
            _uow.SaveChanges();
            Console.WriteLine("✅ Categoría registrada correctamente.");
        }

        public void ListarCategoriasUI()
        {
            Console.WriteLine("Lista de Categorías:");
            Console.WriteLine("--------------------");
            var categorias = _uow.CategoriaService.Listar();
            foreach (var c in categorias)
                Console.WriteLine(c.ToString());
            Console.WriteLine();
        }

        public void BuscarCategoriaUI()
        {
            Console.WriteLine("Buscar categoría a buscar: ");
            Console.WriteLine("---------------------------");
            Console.Write("Ingrese el ID de la categoría: ");
            var id = int.Parse(Console.ReadLine());
            var categoria = _uow.CategoriaService.Buscar(id);
            if (categoria != null)
                Console.WriteLine(categoria.ToString());
            else
                Console.WriteLine("❌ Categoría no encontrada.");
        }

        private void ActualizarCategoriaUI()
        {
            Console.WriteLine("Actualizar categoría:");
            Console.WriteLine("---------------------");
            Console.Write("Ingrese el ID de la categoría a actualizar: ");
            var id = int.Parse(Console.ReadLine());
            var categoria = _uow.CategoriaService.Buscar(id);
            if (categoria == null)
            {
                Console.WriteLine("❌ Categoría no encontrada.");
                return;
            }

            Console.WriteLine("Ingrese nuevos datos (dejar vacío para mantener el actual):");

            Console.Write($"Nombre ({categoria.Nombre}): ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) categoria.Nombre = nombre;

            Console.WriteLine($"Descripcion ({categoria.Descripcion}): ");
            var descripcion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(descripcion)) categoria.Descripcion = descripcion;

            _uow.CategoriaService.Actualizar(categoria);
            _uow.SaveChanges();
            Console.WriteLine("✅ Categoría actualizada correctamente.");
        }

        private void EliminarCategoriaUI()
        {
            Console.WriteLine("Eliminar categoría:");
            Console.WriteLine("-------------------");
            Console.Write("Ingrese el ID de la categoría a eliminar: ");
            var id = int.Parse(Console.ReadLine());
            var categoria = _uow.CategoriaService.Buscar(id);
            if (categoria == null)
            {
                Console.WriteLine("❌ Categoría no encontrada.");
                return;
            }
            _uow.CategoriaService.Eliminar(id);
            _uow.SaveChanges();
            Console.WriteLine("✅ Categoría eliminada correctamente.");
        }

        private Categoria CapturarDatosCategoria()
        {
            var categoria = new Categoria();

            Console.Write("Nombre: ");
            categoria.Nombre = Console.ReadLine();

            Console.Write("Descripción: ");
            categoria.Descripcion = Console.ReadLine();

            return categoria;
        }
    }
}

using CRUD_Consola.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Consola.Utils
{
    internal class DatabaseConUtils
    {
        public static void EnsureDatabaseCreated(AppDbContext context)
        {

            try
            {
                Console.WriteLine("Probando conexión a la base de datos...");

                if (context.Database.CanConnect())
                {
                    Console.WriteLine("✅ Conexión exitosa con la base de datos.");
                    return; // 👈 Early return: si conecta, no seguimos
                }

                Console.WriteLine("❌ No se pudo conectar. Creando la base de datos...");
                context.Database.EnsureCreated();
                Console.WriteLine("✅ Base de datos creada exitosamente.");
            }
            catch (SqlException sqlEx)
            {
                // Diferenciar errores comunes por código
                switch (sqlEx.Number)
                {
                    case 53:   // Servidor no accesible
                        Console.WriteLine("❌ No se encontró el servidor o instancia.");
                        break;
                    case 4060: // Base de datos no existe
                        Console.WriteLine("❌ La base de datos especificada no existe.");
                        break;
                    case 18456: // Error de login
                        Console.WriteLine("❌ Error de autenticación: usuario o contraseña incorrectos.");
                        break;
                    default:
                        Console.WriteLine($"❌ Error SQL ({sqlEx.Number}): {sqlEx.Message}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error inesperado: {ex.Message}");
            }
        }
    }
}

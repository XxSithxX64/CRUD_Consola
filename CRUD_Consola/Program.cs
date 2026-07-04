using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json",
                 optional: false,
                 reloadOnChange: true)
    .Build();
var connectionString = configuration.GetConnectionString("DefaultConnection");

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new AppDbContext(options);
try
{
    Console.WriteLine("Probando conexión a la base de datos...");
    bool canConnect = context.Database.CanConnect();
    Console.WriteLine(canConnect
        ? "✅ Conexión exitosa con la base de datos."
        : "❌ No se pudo conectar a la base de datos.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error de conexión: {ex.Message}");
}

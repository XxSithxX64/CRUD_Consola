using CRUD_Consola._2.Infrastructure.Repositories;
using CRUD_Consola._2Infrastructure.Repositories;
using CRUD_Consola._3Application.Services;
using CRUD_Consola._4UI;
using CRUD_Consola.Application.Services;
using CRUD_Consola.Infrastructure.Data;
using CRUD_Consola.UI;
using CRUD_Consola.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// 1. ConfigurationBuilder. nos permite leer archivos de configuracion externos
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json",
                 optional: false,
                 reloadOnChange: true)
    .Build();

//2. obtener la cadena de conexion 
var connectionString = configuration.GetConnectionString("DefaultConnection");

//3. Configurar las opciones que necesita el InventarioContext
// sqlserver
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(connectionString)
    .Options;

//4. Crear una instancia del contexto BloggingContext
using var context = new AppDbContext(options);

//5. Llamar al metodo que verifica la existencia de la base de datos y crea la base de datos si no existe
DatabaseConUtils.EnsureDatabaseCreated(context);
Console.ReadKey();

//6. Crear una instancia del servicio de cliente
var clienteService = new ClienteService(new ClienteRepository(context));

//7 Ahora delegas la UI a la clase
//var uiCliente = new ClienteConsoleUI(clienteService);
//uiCliente.MostrarMenu();

var uiMenu = new MenuConsoleUI(
    new ClienteConsoleUI(clienteService),
    new SucursalConsoleUI(new SucursalService(new SucursalRepository(context)))
);

uiMenu.MostrarMenu();
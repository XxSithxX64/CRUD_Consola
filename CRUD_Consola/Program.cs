using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola._4UI;
using CRUD_Consola.Infrastructure.Data;
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
var context = new AppDbContext(options);

//5. Llamar al metodo que verifica la existencia de la base de datos y crea la base de datos si no existe
DatabaseConUtils.EnsureDatabaseCreated(context);
Console.ReadKey();

//6. Crear una instancia de UnitOfWork y pasarle el contexto
var uow = new UnitOfWork(context);

//7. Crear una instancia de MenuConsoleUI y pasarle la instancia de UnitOfWork
var uiMenu = new MenuConsoleUI(uow);
uiMenu.MostrarMenu();
using CRUD_Consola._1Core.IRepository;
using CRUD_Consola._1Core.IService;
using CRUD_Consola._2Infrastructure.Repositories;
using CRUD_Consola._3Application.Services;
using CRUD_Consola._3Application.UnitOfWork;
using CRUD_Consola._4UI;
using CRUD_Consola.Core.Entities;
using CRUD_Consola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD_Consola
{
    public class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Registrar DbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();
            services.AddScoped<IPagoRepository, PagoRepository>();

            // Register services
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IDetallePedidoService, DetallePedidoService>();
            services.AddScoped<IFacturaService, FacturaService>();
            services.AddScoped<IPagoService, PagoService>();

            // Registrar UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Registrar UI
            services.AddScoped<MenuConsoleUI>();

            return services;
        }
    }
}

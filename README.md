# 🛠️ CRUD Consola - Sistema de Gestión Empresarial

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-10.0.9-512BD4)](https://docs.microsoft.com/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Express-CC2927?logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

Sistema integral de gestión empresarial desarrollado en **.NET 10** con arquitectura por capas, implementando patrones de diseño modernos y mejores prácticas de desarrollo.

---

## 📋 Tabla de Contenidos

- [Características](#-características)
- [Arquitectura del Proyecto](#-arquitectura-del-proyecto)
- [Tecnologías Utilizadas](#-tecnologías-utilizadas)
- [Requisitos Previos](#-requisitos-previos)
- [Instalación](#-instalación)
- [Configuración](#-configuración)
- [Uso](#-uso)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Patrones de Diseño](#-patrones-de-diseño)
- [Base de Datos](#-base-de-datos)
- [Roadmap](#-roadmap)
- [Contribución](#-contribución)
- [Licencia](#-licencia)

---

## ✨ Características

### Módulos Principales
- 👥 **Gestión de Clientes**: CRUD completo con validaciones
- 📦 **Gestión de Productos**: Control de inventario y categorías
- 🏷️ **Categorías**: Clasificación de productos
- 🏢 **Proveedores**: Administración de suministradores
- 👨‍💼 **Empleados**: Gestión de personal
- 🏪 **Sucursales**: Control de múltiples ubicaciones
- 🛒 **Pedidos**: Sistema completo de órdenes con detalles
- 📄 **Facturas**: Generación y seguimiento de facturas
- 💳 **Pagos**: Registro de transacciones

### Características Técnicas
- ✅ Arquitectura en capas (Domain, Infrastructure, Application, UI, Utils)
- ✅ Inyección de Dependencias (DI)
- ✅ Patrón Repository
- ✅ Unit of Work para transacciones coordinadas
- ✅ Logging estructurado con Microsoft.Extensions.Logging
- ✅ Manejo centralizado de excepciones
- ✅ Helpers de consola con colores y validaciones
- ✅ Entity Framework Core con migraciones Code-First
- ✅ Configuración por entorno (appsettings.json)

---

## 🏗️ Arquitectura del Proyecto

```
┌──────────────────────────────────────────────────────┐
│                    4UI (Console UI)                  │
│  ClienteUI │ ProductoUI │ PedidoUI │ FacturaUI...    │
└───────────────────────┬──────────────────────────────┘
                        │
┌───────────────────────▼──────────────────────────────┐
│           3Application (Business Logic)              │
│    Services │ UnitOfWork │ ServiceConfiguration      │
└───────────────────────┬──────────────────────────────┘
                        │
┌───────────────────────▼──────────────────────────────┐
│         2Infrastructure (Data Access)                │
│   Repositories │ AppDbContext │ Migrations           │
└───────────────────────┬──────────────────────────────┘
                        │
┌───────────────────────▼──────────────────────────────┐
│              1Core (Domain Layer)                    │
│   Entities │ IRepository │ IService │ Interfaces     │
└──────────────────────────────────────────────────────┘
```

### Flujo de Datos
```
Usuario → UI → Service → Repository → DbContext → SQL Server
                ↓
          UnitOfWork (coordina SaveChanges)
```

---

## 🚀 Tecnologías Utilizadas

| Categoría | Tecnología | Versión |
|-----------|-----------|---------|
| **Framework** | .NET | 10.0 |
| **ORM** | Entity Framework Core | 10.0.9 |
| **Base de Datos** | SQL Server Express | 2022+ |
| **Logging** | Microsoft.Extensions.Logging | 10.0.0 |
| **DI Container** | Microsoft.Extensions.Hosting | 10.0.1 |
| **Configuración** | Microsoft.Extensions.Configuration | 10.0.0 |

---

## 📦 Requisitos Previos

Antes de comenzar, asegúrate de tener instalado:

- ✅ [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (última versión)
- ✅ [SQL Server Express 2022](https://www.microsoft.com/sql-server/sql-server-downloads) o superior
- ✅ [Visual Studio 2026](https://visualstudio.microsoft.com/) (opcional) o Visual Studio Code
- ✅ [Git](https://git-scm.com/) para clonar el repositorio

### Verificar Instalación

```powershell
# Verificar .NET
dotnet --version
# Debe mostrar 10.x.x

# Verificar SQL Server (en SSMS o terminal)
sqlcmd -S localhost\SQLEXPRESS -Q "SELECT @@VERSION"
```

---

## 🔧 Instalación

### 1. Clonar el Repositorio

```bash
git clone https://github.com/XxSithxX64/CRUD_Consola.git
cd CRUD_Consola
```

### 2. Restaurar Dependencias

```bash
dotnet restore
```

### 3. Configurar Base de Datos

Edita el archivo `appsettings.json` con tu cadena de conexión:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=CRUD_ConsoleDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 4. Aplicar Migraciones (Opcional)

Si prefieres usar migraciones en lugar de creación automática:

```bash
# Crear migración inicial
dotnet ef migrations add InitialCreate --project CRUD_Consola

# Aplicar a la base de datos
dotnet ef database update --project CRUD_Consola
```

### 5. Compilar y Ejecutar

```bash
# Compilar
dotnet build

# Ejecutar
dotnet run --project CRUD_Consola
```

O desde Visual Studio: presiona `F5` o `Ctrl + F5`.

---

## ⚙️ Configuración

### Archivo `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=CRUD_ConsoleDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.EntityFrameworkCore": "Warning"
    }
  }
}
```

### Variables de Entorno (Opcional)

Para producción, puedes usar variables de entorno:

```powershell
$env:ConnectionStrings__DefaultConnection = "Server=prod-server;Database=CRUD_ConsoleDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
```

---

## 🎯 Uso

### Menú Principal

Al ejecutar la aplicación, verás el menú principal:

```
=== MENÚ PRINCIPAL ===
1. Clientes
2. Productos
3. Categorías
4. Proveedores
5. Empleados
6. Sucursales
7. Pedidos
8. Detalles de Pedido
9. Facturas
10. Pagos
0. Salir
```

### Ejemplo: Crear un Cliente

1. Selecciona `1` (Clientes)
2. Selecciona `1` (Crear Cliente)
3. Ingresa los datos:
   ```
   Nombre: Juan Pérez
   Email: juan@example.com
   Teléfono: 1234567890
   ```
4. El sistema confirmará la creación con un mensaje verde ✅

### Ejemplo: Crear un Pedido Completo

1. Selecciona `7` (Pedidos)
2. Selecciona `1` (Crear Pedido)
3. Ingresa ID de Cliente y Empleado
4. Agrega productos al detalle del pedido
5. El sistema calculará el total automáticamente

---

## 📁 Estructura del Proyecto

```
CRUD_Consola/
│
├── 1Core/                          # Capa de Dominio
│   ├── Entities/                   # Entidades del dominio
│   │   ├── Cliente.cs
│   │   ├── Producto.cs
│   │   ├── Pedido.cs
│   │   └── ...
│   ├── IRepository/                # Interfaces de repositorios
│   │   └── IRepository.cs
│   └── IService/                   # Interfaces de servicios
│       └── IService.cs
│
├── 2Infrastructure/                # Capa de Infraestructura
│   ├── Data/                       # DbContext
│   │   └── AppDbContext.cs
│   └── Repositories/               # Implementaciones de repositorios
│       └── Repository.cs
│
├── 3Application/                   # Capa de Aplicación
│   ├── Services/                   # Lógica de negocio
│   │   ├── Service.cs
│   │   └── ServiceConfiguration.cs
│   └── UnitOfWork/                 # Patrón Unit of Work
│       ├── IUnitOfWork.cs
│       └── UnitOfWork.cs
│
├── 4UI/                            # Capa de Presentación
│   ├── ClienteConsoleUI.cs
│   ├── ProductoConsoleUI.cs
│   ├── PedidoConsoleUI.cs
│   ├── MenuConsoleUI.cs
│   └── ...
│
├── 5Utils/                         # Utilidades
│   ├── ConsoleHelper.cs            # Helpers de consola (colores, validaciones)
│   └── DatabaseConUtils.cs         # Utilidades de base de datos
│
├── appsettings.json                # Configuración de la aplicación
├── Program.cs                      # Punto de entrada
├── CRUD_Consola.csproj             # Archivo de proyecto
├── GUIA_MANEJO_EXCEPCIONES.md      # Guía de implementación
└── README.md                       # Este archivo
```

---

## 🎨 Patrones de Diseño

### 1. Repository Pattern
Abstrae el acceso a datos y centraliza la lógica de persistencia.

```csharp
public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
}
```

### 2. Unit of Work Pattern
Coordina el trabajo de múltiples repositorios y garantiza transacciones atómicas.

```csharp
public interface IUnitOfWork
{
    IService<Cliente> Clientes { get; }
    IService<Producto> Productos { get; }
    // ...
    int SaveChanges();
}
```

### 3. Dependency Injection
Reduce el acoplamiento y facilita las pruebas unitarias.

```csharp
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped(typeof(IService<>), typeof(Service<>));
```

### 4. Service Layer Pattern
Encapsula la lógica de negocio y coordina operaciones complejas.

```csharp
public class Service<T> : IService<T> where T : class
{
    private readonly IRepository<T> _repository;

    public void Crear(T entidad)
    {
        // Validaciones y lógica de negocio
        _repository.Add(entidad);
    }
}
```

---

## 🔒 Validaciones y Data Annotations

### ¿Qué son las Data Annotations?

Las **Data Annotations** son atributos que se aplican a las propiedades de las entidades para:
- ✅ Validar datos antes de guardarlos
- ✅ Configurar el esquema de la base de datos
- ✅ Mejorar la documentación del código
- ✅ Funcionar automáticamente con EF Core y ASP.NET

### Ejemplo de Implementación

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cliente
{
    [Key] // Clave primaria
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MaxLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
    public string Nombre { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    [MaxLength(150)]
    public string Email { get; set; }

    [Required]
    [Phone(ErrorMessage = "Formato de teléfono inválido")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Debe contener exactamente 10 dígitos")]
    public string Telefono { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue, ErrorMessage = "El saldo debe ser positivo")]
    public decimal? Saldo { get; set; }
}
```

### Annotations Más Comunes

| Atributo | Propósito | Ejemplo |
|----------|-----------|---------|
| `[Required]` | Campo obligatorio | `[Required(ErrorMessage = "Campo requerido")]` |
| `[MaxLength]` | Longitud máxima | `[MaxLength(100)]` |
| `[MinLength]` | Longitud mínima | `[MinLength(3)]` |
| `[Range]` | Rango numérico | `[Range(0, 100)]` |
| `[EmailAddress]` | Validar email | `[EmailAddress]` |
| `[Phone]` | Validar teléfono | `[Phone]` |
| `[RegularExpression]` | Patrón regex | `[RegularExpression(@"^\d+$")]` |
| `[Column]` | Configurar columna DB | `[Column(TypeName = "decimal(18,2)")]` |
| `[ForeignKey]` | Clave foránea | `[ForeignKey("CategoriaId")]` |
| `[NotMapped]` | Excluir de BD | `[NotMapped]` |

### Validación Manual en Servicios

```csharp
public class Service<T> : IService<T> where T : class
{
    public void Crear(T entidad)
    {
        // Validar usando Data Annotations
        var contextoValidacion = new ValidationContext(entidad);
        var resultados = new List<ValidationResult>();

        if (!Validator.TryValidateObject(entidad, contextoValidacion, resultados, true))
        {
            var errores = string.Join(", ", resultados.Select(r => r.ErrorMessage));
            throw new ValidationException($"Errores de validación: {errores}");
        }

        _repository.Add(entidad);
    }
}
```

---

## 🗄️ Base de Datos

### Modelo de Datos

El sistema gestiona las siguientes entidades relacionadas:

- **Cliente** → Pedido (1:N)
- **Empleado** → Pedido (1:N)
- **Sucursal** → Pedido (1:N)
- **Pedido** → DetallePedido (1:N)
- **Producto** → DetallePedido (1:N)
- **Categoria** → Producto (1:N)
- **Proveedor** → Producto (1:N)
- **Pedido** → Factura (1:1)
- **Factura** → Pago (1:N)

### Entidades Principales

| Entidad           | Descripción               | Campos Clave |
|---------          |-------------              |--------------|
| **Cliente**       | Información de clientes   | Nombre, Email, Teléfono |
| **Producto**      | Catálogo de productos     | Nombre, Precio, Stock, CategoriaId |
| **Pedido**        | Órdenes de compra         | Fecha, Total, ClienteId, EmpleadoId |
| **DetallePedido** | Líneas de pedido          | Cantidad, PrecioUnitario, ProductoId |
| **Factura**       | Documentos fiscales       | Numero, Fecha, Total, PedidoId |
| **Pago**          | Transacciones             | Monto, FechaPago, MetodoPago |

### Creación Automática

La base de datos se crea automáticamente al iniciar la aplicación si no existe:

```csharp
// En Program.cs
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
DatabaseConUtils.EnsureDatabaseCreated(dbContext);
```

---

## 🗺️ Roadmap

### ✅ Completado
- [x] Arquitectura en capas
- [x] Patrones Repository y Unit of Work
- [x] Inyección de dependencias
- [x] Logging estructurado
- [x] Manejo de excepciones
- [x] Helpers de consola con colores

### 🚧 En Progreso
- [ ] Refactorización completa de todas las UI con `ConsoleHelper`
- [ ] Implementación de async/await en toda la aplicación
- [ ] Validaciones con FluentValidation

### 📅 Planeado
- [ ] **Data Annotations** en entidades (Required, MaxLength, Range, etc.)
- [ ] Soft Delete (borrado lógico)
- [ ] Auditoría automática (CreatedAt, UpdatedAt)
- [ ] Paginación y filtros avanzados
- [ ] Exportación de reportes a CSV/Excel
- [ ] Búsqueda dinámica por múltiples campos
- [ ] Caché de datos frecuentes
- [ ] Retry Policy para resiliencia
- [ ] Transacciones explícitas para operaciones complejas
- [ ] Migración a API Web (ASP.NET Core)
- [ ] Interfaz Blazor/MAUI

---

## 🤝 Contribución

¡Las contribuciones son bienvenidas! Si deseas colaborar:

1. **Fork** el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un **Pull Request**

### Guías de Contribución

- Sigue las convenciones de código existentes
- Agrega pruebas para nuevas características
- Actualiza la documentación según sea necesario
- Usa mensajes de commit descriptivos

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

---

## 👤 Autor

**XxSithxX64**

- GitHub: [@XxSithxX64](https://github.com/XxSithxX64)
- Proyecto: [CRUD_Consola](https://github.com/XxSithxX64/CRUD_Consola)

---

## 🙏 Agradecimientos

- Comunidad de .NET por las excelentes herramientas
- Entity Framework Core por simplificar el acceso a datos
- Microsoft por la documentación completa

---

## 📞 Soporte

Si encuentras algún problema o tienes preguntas:

1. Revisa la sección de [Issues](https://github.com/XxSithxX64/CRUD_Consola/issues)
2. Crea un nuevo issue con detalles del problema
3. Incluye logs y pasos para reproducir el error

---

## 📊 Estado del Proyecto

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![Maintenance](https://img.shields.io/badge/maintenance-active-green)

---

**⭐ Si este proyecto te fue útil, considera darle una estrella en GitHub!**

---

## 📚 Recursos Adicionales

- [Documentación de .NET](https://docs.microsoft.com/dotnet/)
- [Guía de Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [Patrones de Diseño en C#](https://refactoring.guru/design-patterns/csharp)
- [Guía de Manejo de Excepciones](GUIA_MANEJO_EXCEPCIONES.md)

---

*Última actualización: 2026*

# PrintingJob 

# 1. How to Run the App

### Requisitos Previos
- .NET 8.0 o superior
- SQL Server o SQL Server Express
- Visual Studio 2022 

### Pasos para Ejecutar
 **Clonar o descargar el proyecto**
 <https://github.com/Kard06678/PrintingJob.git>

### Technologies Used
Backend:
- ASP.NET Core 8.0 
- Blazor Server
- Entity Framework Core
- SQL Server 2022
- C# 12 

Frontend:
- Blazor Components
 - Bootstrap 5 
- Feather Icons 
- HTML5 / CSS3
- JavaScript Interop

### Herramientas y Librerías:
- Entity Framework Core Migrations - Versionamiento de esquema
- Dependency Injection - Inyeccion de dependencias integrada

### Limitaciones
Limitacion 1: Autenticacion
 - El sistema no tiene autenticacion implementada, cualquier usuario puede acceder a todas las funcionalidades.

Limitacion 2: Notificaciones
- No hay sistema de notificaciones por email o alertas de SLA vencidos.

### Comandos Para Correr ENTITY Framework localdb
Abrir CMD o Powershell
# 1) Ir a la carpeta del repo y listar los .csproj para validar rutas
cd C:\Users\oscar\Desktop\PrintingJob\PrintingJob
dir -Recurse -Filter *.csproj

# 2) Entrar a la carpeta del proyecto que contiene el .csproj (según tu salida)
cd C:\Users\oscar\Desktop\PrintingJob\PrintingJob1

# 3) si no tiene dotnet-ef
dotnet tool install --global dotnet-ef
# o si ya la tiene:
# dotnet tool update --global dotnet-ef

# 4) Restaurar y compilar (asegúrate que todo compila)
dotnet restore
dotnet build

# 5) (Si aún NO tienes migraciones) crear la migración inicial
dotnet ef migrations add InitialCreate --verbose

# 6) Generar script idempotente de todas las migraciones (migrations.sql)
dotnet ef migrations script --idempotent -o migrations.sql --verbose

-actualizar base de datos
dotnet ef database update --verbose



















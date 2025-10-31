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
# 1) Ir a la carpeta del repo y listar los .csproj 
cd C:\Users\oscar\Desktop\PrintingJob\PrintingJob
dir -Recurse -Filter *.csproj

# 2) Entrar a la carpeta del proyecto que contiene el .csproj 
cd C:\Users\oscar\Desktop\PrintingJob\PrintingJob1

# 3) si no tiene dotnet-ef
dotnet tool install --global dotnet-ef

# 4) si ya tiene dotnet-ef
dotnet tool update --global dotnet-ef

# 5) Restaurar y compilar 
dotnet restore
dotnet build

# 6) crear la migracion 
dotnet ef migrations add MigracionImport --verbose

# 7) actualizar base de datos
dotnet ef database update --verbose



















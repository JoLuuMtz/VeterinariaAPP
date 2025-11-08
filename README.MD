 # Veterinaria API (ASP.NET Core 9 + EF Core + SQL Server)
 
 API REST para la gestión de una clínica veterinaria: clientes, veterinarios, mascotas, citas, historial médico y medicamentos.


 # PRODUCCION: http://veterinaria-api.somee.com/api/ 
 
 Incluye controladores, servicios, repositorios, DTOs con validaciones por FluentValidation, Entity Framework Core con SQL Server y documentación Swagger (en entorno Development).
 
 ---
 
 ## Requisitos
 
 - .NET SDK 9.0
 - SQL Server (local o remoto)
 - PowerShell/Terminal
 - Opcional: Docker 24+ y Docker Desktop
 - Opcional: Visual Studio 2022 17.12+ o VS Code
 
 ---
 
 ## Dependencias (NuGet)
 
 - FluentValidation 12.1.0
 - FluentValidation.AspNetCore 11.3.1
 - FluentValidation.DependencyInjectionExtensions 12.1.0
 - Microsoft.AspNetCore.OpenApi 9.0.10
 - Microsoft.EntityFrameworkCore 9.0.10
 - Microsoft.EntityFrameworkCore.SqlServer 9.0.10
 - Microsoft.EntityFrameworkCore.Tools 9.0.10
 - Microsoft.VisualStudio.Azure.Containers.Tools.Targets 1.22.1
 - Swashbuckle.AspNetCore 9.0.6
 
 Todas definidas en `Veterinaria.csproj` (TargetFramework: `net9.0`).
 
 ---
 
 ## Estructura del proyecto
 
 - `Program.cs`: configuración de servicios, Swagger y pipeline HTTP
 - `Data/`: `VeterinariaDB` (DbContext) e índices únicos
 - `Models/`: entidades de dominio
 - `DTOs/`: modelos de entrada/salida
 - `Validators/`: validaciones de DTOs con FluentValidation
 - `Repository/`: acceso a datos por entidad (EF Core)
 - `Services/`: lógica de negocio y validaciones de unicidad
 - `Controllers/`: endpoints REST (`api/[controller]`)
 - `Migrations/`: migraciones de EF Core y snapshot del modelo
 - `Properties/launchSettings.json`: perfiles de ejecución locales
 - `Dockerfile`: imagen multi-stage (SDK 9.0 y ASP.NET 9.0)
 
 ---
 
 ## Configuración
 
 1) Variables de entorno principales
 
 - `ASPNETCORE_ENVIRONMENT`: `Development` (habilita Swagger) o `Production`
 - `ConnectionStrings:VeterinariaDB`: cadena de conexión a SQL Server
 
 2) appsettings
 
 - `appsettings.json` contiene `ConnectionStrings:VeterinariaDB`. Para desarrollo, no exponga secretos y sobrescríbalo con User Secrets o variables de entorno.
 
 3) User Secrets (recomendado en desarrollo)
 
 ```bash
 # Desde la raíz del proyecto (donde está Veterinaria.csproj)
 dotnet user-secrets init
 # Establecer la cadena de conexión (ejemplos)
 # Autenticación integrada
 dotnet user-secrets set "ConnectionStrings:VeterinariaDB" "Server=localhost;Database=VeterinariaDB;Trusted_Connection=True;Trust Server Certificate=True"
 # Usuario/contraseña SQL
 dotnet user-secrets set "ConnectionStrings:VeterinariaDB" "Server=localhost;Database=VeterinariaDB;User Id=sa;Password=SuPassword!;Trust Server Certificate=True"
 ```
 
 4) Variables de entorno (alternativa)
 
 - Windows PowerShell:
 
 ```powershell
 $env:ConnectionStrings__VeterinariaDB = "<cadena>"
 ```
 
 - Linux/macOS:
 
 ```bash
 export ConnectionStrings__VeterinariaDB="<cadena>"
 ```
 
 ---
 
 ## Ejecución local (CLI)
 
 1) Restaurar y compilar
 
 ```bash
 dotnet restore
 dotnet build
 ```
 
 2) Aplicar migraciones (crear/actualizar la base de datos)
 
 ```bash
 # Requiere la herramienta de EF Core
 # Si no la tiene: dotnet tool install --global dotnet-ef
 dotnet ef database update
 ```
 
 3) Ejecutar
 
 ```bash
 dotnet run
 ```
 
 - URLs por defecto (launchSettings):
   - HTTP: http://localhost:5013
   - HTTPS: https://localhost:7272
 - Swagger UI (en Development): raíz del sitio (`/`).
   - Ej.: http://localhost:5013/
   - JSON: `/swagger/v1/swagger.json`
 
 Sugerencia (HTTPS local):
 
 ```bash
 dotnet dev-certs https --trust
 ```
 
 ---
 
 ## Documentación (Swagger/OpenAPI)
 
 - Activada en `Development`.
 - Título: "Veterinaria API Jorge Martinez Y Fabio Trujillo".
 - Ubicación:
   - UI: `/` (RoutePrefix vacío)
   - JSON: `/swagger/v1/swagger.json`
 
 Para exponer Swagger en `Production`, mueva `UseSwagger()` y `UseSwaggerUI()` fuera de la condición de entorno según su criterio de seguridad.
 
 ---
 
 ## Base de datos y migraciones (EF Core)
 
 DbContext: `VeterinariaApp.Data.VeterinariaDB`
 
 Índices únicos configurados por Fluent API (ejemplos):
 - `Clientes`: `DocumentoIdentidad`, `Email` (filtrado), `Telefono` (filtrado)
 - `Veterinarios`: `DocumentoIdentidad`, `Email` (filtrado), `Telefono` (filtrado), `NumeroLicencia` (filtrado)
 
 Migraciones incluidas (carpeta `Migrations/`):
 - `InitialCreate`
 - `Migration2`
 - `OpcionalClientInMascota`
 - `LastOneMigrations`
 
 Comandos útiles:
 
 ```bash
 # Instalar herramienta EF (si no la tiene)
 dotnet tool install --global dotnet-ef
 
 # Agregar una migración
 dotnet ef migrations add <Nombre>
 
 # Aplicar migraciones a la BD
 dotnet ef database update
 
 # Revertir última migración (sin aplicar cambios a BD)
 dotnet ef migrations remove
 
 # Generar script SQL
 dotnet ef migrations script
 ```
 
 ---
 
 ## Docker
 
 El proyecto incluye un `Dockerfile` multi-stage.
 
 1) Construir imagen
 
 ```bash
 docker build -t veterinaria-api .
 ```
 
 2) Ejecutar contenedor (HTTP 8080)
 
 ```bash
 docker run --rm -p 8080:8080 \
   -e ASPNETCORE_ENVIRONMENT=Development \
   -e ConnectionStrings__VeterinariaDB="<cadena>" \
   veterinaria-api
 ```
 
 - Acceso: http://localhost:8080/
 - Swagger UI estará disponible en Development.
 - Nota: Por defecto se publica solo HTTP en el contenedor. Para HTTPS se requiere configuración de certificados dentro del contenedor.
 
 ---
 
 ## Validaciones y reglas de negocio
 
 - Validación de datos en DTOs con FluentValidation (carpeta `Validators/`).
 - Reglas de unicidad (email, teléfono, documento, licencia) validadas en `Services` antes de persistir.
 - Índices únicos en la base de datos (Fluent API) como respaldo para garantizar integridad.
 
 ---
 
 ## Endpoints principales (prefijo `api/`)
 
 - `api/Cliente`
 - `api/Veterinario`
 - `api/Mascota`
 - `api/Cita`
 - `api/HistorialMedico`
 - `api/Medicamento`
 
 Métodos CRUD disponibles en cada controlador: GET, GET `{id}`, POST, PUT `{id}`, DELETE `{id}`.
 
 ---
 
 ## Solución de problemas
 
 - dotnet-ef no se encuentra: instale la herramienta global `dotnet tool install --global dotnet-ef` y reinicie la terminal.
 - Swagger no aparece: verifique `ASPNETCORE_ENVIRONMENT=Development` o mueva `UseSwagger()`/`UseSwaggerUI()` fuera de la condición de entorno.
 - Error de conexión a SQL Server: verifique firewall, credenciales y `Trust Server Certificate=True` si usa certificados autofirmados.
 - Puerto en uso: cambie puertos en `launchSettings.json` o pase `--urls` al ejecutar `dotnet run`.
 
 ---
 
 ## Créditos
 
 - ASP.NET Core 9, EF Core 9 y Swagger.
 - Documentación XML habilitada (`GenerateDocumentationFile=true`) e integrada a Swagger.
 

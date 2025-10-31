using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using Veterinaria;
using Veterinaria.Interfaces;
using Veterinaria.Repository;
using Veterinaria.Services;
using VeterinariaApp.Data;

namespace Veterinaria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Base de datos Entity Framework
            builder.Services.AddDbContext<VeterinariaDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VeterinariaDB")));

            // Add services to the container.
            builder.Services.AddControllers();
            
            // Configuración de Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Veterinaria API",
                    Version = "v1",
                    Description = "API para gestión de clínica veterinaria"
                });
            });

            // Registro de Repositorios
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
            builder.Services.AddScoped<IMascotaRepository, MascotaRepository>();
            builder.Services.AddScoped<ICitaRepository, CitaRepository>();
            builder.Services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
            builder.Services.AddScoped<IHistorialMedicoRepository, HistorialMedicoRepository>();

            // Registro de Servicios
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();
            builder.Services.AddScoped<IMascotaService, MascotaService>();
            builder.Services.AddScoped<ICitaService, CitaService>();
            builder.Services.AddScoped<IMedicamentoService, MedicamentoService>();
            builder.Services.AddScoped<IHistorialMedicoService, HistorialMedicoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Veterinaria API v1");
                    c.RoutePrefix = string.Empty; // Para que Swagger UI esté en la raíz
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            

            app.Run();
        }
    }
}
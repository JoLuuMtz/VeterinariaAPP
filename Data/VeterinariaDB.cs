// Data/VeterinariaDbContext.cs

using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;
using VeterinariaApp.Models;


namespace VeterinariaApp.Data
{
    public class VeterinariaDB : DbContext
    {
        public VeterinariaDB(DbContextOptions<VeterinariaDB> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                // Índice único para DocumentoIdentidad en Clientes
                entity.HasIndex(e => e.DocumentoIdentidad)
                    .IsUnique()
                    .HasDatabaseName("IX_Clientes_DocumentoIdentidad_Unique");

                // Índice único para Email en Clientes
                entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasDatabaseName("IX_Clientes_Email_Unique")
                    .HasFilter("[Email] IS NOT NULL AND [Email] != ''");

                // Índice único para Telefono en Clientes
                entity.HasIndex(e => e.Telefono)
                    .IsUnique()
                    .HasDatabaseName("IX_Clientes_Telefono_Unique")
                    .HasFilter("[Telefono] IS NOT NULL AND [Telefono] != ''");
            });

            // Configuración para Veterinario
            modelBuilder.Entity<Veterinario>(entity =>
            {
                // Índice único para DocumentoIdentidad en Veterinarios
                entity.HasIndex(e => e.DocumentoIdentidad)
                    .IsUnique()
                    .HasDatabaseName("IX_Veterinarios_DocumentoIdentidad_Unique");

                // Índice único para Email en Veterinarios
                entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasDatabaseName("IX_Veterinarios_Email_Unique")
                    .HasFilter("[Email] IS NOT NULL AND [Email] != ''");

                // Índice único para Telefono en Veterinarios
                entity.HasIndex(e => e.Telefono)
                    .IsUnique()
                    .HasDatabaseName("IX_Veterinarios_Telefono_Unique")
                    .HasFilter("[Telefono] IS NOT NULL AND [Telefono] != ''");

                // Índice único para NumeroLicencia en Veterinarios
                entity.HasIndex(e => e.NumeroLicencia)
                    .IsUnique()
                    .HasDatabaseName("IX_Veterinarios_NumeroLicencia_Unique")
                    .HasFilter("[NumeroLicencia] IS NOT NULL AND [NumeroLicencia] != ''");
                
            });
        }
    }
}
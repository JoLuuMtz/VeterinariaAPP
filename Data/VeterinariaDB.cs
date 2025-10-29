// Data/VeterinariaDbContext.cs
using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;
using VeterinariaApp.Models;


namespace VeterinariaApp.Data
{
    public class VeterinariaDbContext : DbContext
    {
        public VeterinariaDbContext(DbContextOptions<VeterinariaDbContext> options)
            : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }



    }
}
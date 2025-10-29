using System.ComponentModel.DataAnnotations;
using Veterinaria.Models;

namespace Veterinaria.Models
{
    public class Veterinario : Persona // hereda de persona
    {
        [MaxLength(50)]
        public string NumeroLicencia { get; set; }

        [MaxLength(100)]
        public string Especialidad { get; set; }

        public DateTime FechaContratacion { get; set; } = DateTime.Now;

        // Relaciones
        public ICollection<Cita> Citas { get; set; }
        public ICollection<HistorialMedico> HistorialMedico { get; set; }
    }
}
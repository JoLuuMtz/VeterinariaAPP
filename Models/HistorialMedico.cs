// Models/HistorialMedico.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veterinaria.Models;

namespace Veterinaria.Models
{
    public class HistorialMedico
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(100)]
        public string TipoConsulta { get; set; } // Vacunación, Cirugía, Consulta General, etc.

        [MaxLength(2000)]
        public string Diagnostico { get; set; }

        [MaxLength(2000)]
        public string Tratamiento { get; set; }

        [MaxLength(1000)]
        public string Observaciones { get; set; }

        public decimal PesoRegistrado { get; set; }

        [MaxLength(100)]
        public string Temperatura { get; set; }

        // Llaves foráneas
        [ForeignKey("Mascota")]
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; }

        [ForeignKey("Veterinario")]
        public int VeterinarioId { get; set; }
        public Veterinario Veterinario { get; set; }

        // Relaciones
        public ICollection<Medicamento> Medicamentos { get; set; }
    }
}
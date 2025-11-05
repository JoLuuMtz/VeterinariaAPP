using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veterinaria.Models;

namespace Veterinaria.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaHora { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } // Pendiente, Confirmada, Completada, Cancelada

        [MaxLength(500)]
        public string Motivo { get; set; }

        [MaxLength(1000)]
        public string Observaciones { get; set; }

        // Llaves foráneas
        [ForeignKey("Mascota")]
        public int MascotaId { get; set; } // depende de la tabla Mascota
        public Mascota Mascota { get; set; }

        [ForeignKey("Veterinario")]
        public int VeterinarioId { get; set; }
        public Veterinario Veterinario { get; set; } // depende de la tabla Veterinario
    } 
}

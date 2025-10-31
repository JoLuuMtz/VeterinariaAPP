using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veterinaria.Models;
using VeterinariaApp.Models;

namespace Veterinaria.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Especie { get; set; } // Perro, Gato, Ave, etc.

        [MaxLength(100)]
        public string Raza { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [MaxLength(10)]
        public string Sexo { get; set; } // Macho, Hembra

        [MaxLength(50)]
        public string Color { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Peso { get; set; }

        [MaxLength(500)]
        public string Observaciones { get; set; }

        public bool Activo { get; set; } = true;

        // Llave foránea
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relaciones
        public ICollection<Cita> Citas { get; set; }
        public ICollection<HistorialMedico> HistorialMedico { get; set; }
    }
}
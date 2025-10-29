using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Models
{
    public class Medicamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }

        [MaxLength(100)]
        public string Dosis { get; set; }

        [MaxLength(100)]
        public string Frecuencia { get; set; }

        public int DuracionDias { get; set; }

        // Llave foránea
        [ForeignKey("HistorialMedico")]
        public int HistorialMedicoId { get; set; }
        public HistorialMedico HistorialMedico { get; set; }
    }
}
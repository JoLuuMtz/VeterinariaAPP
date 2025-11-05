using System.ComponentModel.DataAnnotations;

namespace Veterinaria.DTOs
{
    public class CitaCreateDTO
    {
        public DateTime FechaHora { get; set; }

        [Required] [MaxLength(50)] public string Estado { get; set; }

        [MaxLength(500)] public string Motivo { get; set; }

        [MaxLength(1000)] public string Observaciones { get; set; }

        [Required] public int MascotaId { get; set; }

        [Required] public int VeterinarioId { get; set; }
    }

    public class CitaUpdateDTO
    {
        public DateTime? FechaHora { get; set; }

        [MaxLength(50)] public string? Estado { get; set; }

        [MaxLength(500)] public string? Motivo { get; set; }

        [MaxLength(1000)] public string? Observaciones { get; set; }
    }

    public class CitaResponseDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
        public string Motivo { get; set; }
        public string Observaciones { get; set; }
        public int MascotaId { get; set; }
        public string MascotaNombre { get; set; }
        public int VeterinarioId { get; set; }
        public string VeterinarioNombre { get; set; }
    }
}

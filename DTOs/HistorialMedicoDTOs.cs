using System.ComponentModel.DataAnnotations;

namespace Veterinaria.DTOs
{
    public class HistorialMedicoCreateDTO
    {
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required] [MaxLength(100)] public string TipoConsulta { get; set; }

        [MaxLength(2000)] public string Diagnostico { get; set; }

        [MaxLength(2000)] public string Tratamiento { get; set; }

        [MaxLength(1000)] public string Observaciones { get; set; }

        public decimal PesoRegistrado { get; set; }

        [MaxLength(100)] public string Temperatura { get; set; }

        [Required] public int MascotaId { get; set; }

        [Required] public int VeterinarioId { get; set; }
    }

    public class HistorialMedicoUpdateDTO
    {
        public DateTime? Fecha { get; set; }

        [MaxLength(100)] public string? TipoConsulta { get; set; }

        [MaxLength(2000)] public string? Diagnostico { get; set; }

        [MaxLength(2000)] public string? Tratamiento { get; set; }

        [MaxLength(1000)] public string? Observaciones { get; set; }

        public decimal? PesoRegistrado { get; set; }

        [MaxLength(100)] public string? Temperatura { get; set; }
    }

    public class HistorialMedicoResponseDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoConsulta { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Observaciones { get; set; }
        public decimal PesoRegistrado { get; set; }
        public string Temperatura { get; set; }
        public int MascotaId { get; set; }
        public string MascotaNombre { get; set; }
        public int VeterinarioId { get; set; }
        public string VeterinarioNombre { get; set; }
    }
}

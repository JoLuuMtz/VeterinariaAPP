using System.ComponentModel.DataAnnotations;

namespace Veterinaria.DTOs
{
    public class MedicamentoCreateDTO
    {
        [Required] [MaxLength(200)] public string Nombre { get; set; }

        [MaxLength(500)] public string Descripcion { get; set; }

        [MaxLength(100)] public string Dosis { get; set; }

        [MaxLength(100)] public string Frecuencia { get; set; }

        public int DuracionDias { get; set; }

        [Required] public int HistorialMedicoId { get; set; }
    }

    public class MedicamentoUpdateDTO
    {
        [MaxLength(200)] public string? Nombre { get; set; }

        [MaxLength(500)] public string? Descripcion { get; set; }

        [MaxLength(100)] public string? Dosis { get; set; }

        [MaxLength(100)] public string? Frecuencia { get; set; }

        public int? DuracionDias { get; set; }
    }

    public class MedicamentoResponseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Dosis { get; set; }
        public string Frecuencia { get; set; }
        public int DuracionDias { get; set; }
        public int HistorialMedicoId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Veterinaria.DTOs
{
    public class VeterinarioCreateDTO
    {
        [Required] [MaxLength(100)] public string Nombre { get; set; }

        [Required] [MaxLength(100)] public string Apellido { get; set; }

        [MaxLength(20)] public string Telefono { get; set; }

        [MaxLength(100)] public string Email { get; set; }

        [MaxLength(20)] public string DocumentoIdentidad { get; set; }

        [MaxLength(50)] public string NumeroLicencia { get; set; }

        [MaxLength(100)] public string Especialidad { get; set; }
    }

    public class VeterinarioUpdateDTO
    {
        [MaxLength(100)] public string? Nombre { get; set; }

        [MaxLength(100)] public string? Apellido { get; set; }

        [MaxLength(20)] public string? Telefono { get; set; }

        [MaxLength(100)] public string? Email { get; set; }

        [MaxLength(20)] public string? DocumentoIdentidad { get; set; }

        [MaxLength(50)] public string? NumeroLicencia { get; set; }

        [MaxLength(100)] public string? Especialidad { get; set; }

        public bool? Activo { get; set; }
    }

    public class VeterinarioResponseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string NumeroLicencia { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; }
    }
}

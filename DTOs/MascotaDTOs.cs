using System.ComponentModel.DataAnnotations;

namespace Veterinaria.DTOs
{
    public class MascotaCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Especie { get; set; }

        [MaxLength(100)]
        public string Raza { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [MaxLength(10)]
        public string Sexo { get; set; }

        [MaxLength(50)]
        public string Color { get; set; }

        public decimal Peso { get; set; }

        [MaxLength(500)]
        public string Observaciones { get; set; }

        [Required]
        public int ClienteId { get; set; }
    }

    public class MascotaUpdateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Especie { get; set; }

        [MaxLength(100)]
        public string Raza { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [MaxLength(10)]
        public string Sexo { get; set; }

        [MaxLength(50)]
        public string Color { get; set; }

        public decimal Peso { get; set; }

        [MaxLength(500)]
        public string Observaciones { get; set; }

        public bool Activo { get; set; }
    }

    public class MascotaResponseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Color { get; set; }
        public decimal Peso { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
    }
}

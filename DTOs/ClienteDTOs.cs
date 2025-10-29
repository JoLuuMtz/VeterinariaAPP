using System.ComponentModel.DataAnnotations;

namespace Veterinaria.DTOs
{
    public class ClienteCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string DocumentoIdentidad { get; set; }

        [MaxLength(200)]
        public string Direccion { get; set; }
    }

    public class ClienteUpdateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string DocumentoIdentidad { get; set; }

        [MaxLength(200)]
        public string Direccion { get; set; }

        public bool Activo { get; set; }
    }

    public class ClienteResponseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }
}

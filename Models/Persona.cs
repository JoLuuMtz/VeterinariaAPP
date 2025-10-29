using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models
{
    public abstract class Persona
    {
        [Key]
        public int Id { get; set; }

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

        public bool Activo { get; set; } = true;
    }
}
using System.ComponentModel.DataAnnotations;
using Veterinaria.Models;

namespace VeterinariaApp.Models
{
    public class Cliente : Persona
    {
        [MaxLength(200)]
        public string Direccion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Relaciones
        public ICollection<Mascota> Mascotas { get; set; }
    }
}

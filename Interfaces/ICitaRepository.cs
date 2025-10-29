using Veterinaria.Models;

namespace Veterinaria.Interfaces
{
    public interface ICitaRepository
    {
        Task<IEnumerable<Cita>> GetAllAsync();
        Task<Cita?> GetByIdAsync(int id);
        Task<IEnumerable<Cita>> GetByMascotaIdAsync(int mascotaId);
        Task<IEnumerable<Cita>> GetByVeterinarioIdAsync(int veterinarioId);
        Task<IEnumerable<Cita>> GetByFechaAsync(DateTime fecha);
        Task<Cita> CreateAsync(Cita cita);
        Task<Cita?> UpdateAsync(Cita cita);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}

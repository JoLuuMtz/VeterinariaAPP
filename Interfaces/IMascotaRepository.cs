using Veterinaria.Models;

namespace Veterinaria.Interfaces
{
    public interface IMascotaRepository
    {
        Task<IEnumerable<Mascota>> GetAllAsync();
        Task<Mascota?> GetByIdAsync(int id);
        Task<IEnumerable<Mascota>> GetByClienteIdAsync(int clienteId);
        Task<Mascota> CreateAsync(Mascota mascota);
        Task<Mascota?> UpdateAsync(Mascota mascota);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}

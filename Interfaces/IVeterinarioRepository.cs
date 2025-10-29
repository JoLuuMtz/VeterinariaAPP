using Veterinaria.Models;

namespace Veterinaria.Interfaces
{
    public interface IVeterinarioRepository
    {
        Task<IEnumerable<Veterinario>> GetAllAsync();
        Task<Veterinario?> GetByIdAsync(int id);
        Task<Veterinario> CreateAsync(Veterinario veterinario);
        Task<Veterinario?> UpdateAsync(Veterinario veterinario);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}

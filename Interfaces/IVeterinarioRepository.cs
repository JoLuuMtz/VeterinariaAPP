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
        Task<bool> ExistsByEmailAsync(string email, int? excludeId = null);
        Task<bool> ExistsByDocumentoIdentidadAsync(string documentoIdentidad, int? excludeId = null);
        Task<bool> ExistsByTelefonoAsync(string telefono, int? excludeId = null);
        Task<bool> ExistsByNumeroLicenciaAsync(string numeroLicencia, int? excludeId = null);
    }
}

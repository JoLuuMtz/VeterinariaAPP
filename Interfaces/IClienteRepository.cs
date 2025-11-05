
using VeterinariaApp.Models;

namespace Veterinaria.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task<Cliente?> UpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsByEmailAsync(string email, int? excludeId = null);
        Task<bool> ExistsByDocumentoIdentidadAsync(string documentoIdentidad, int? excludeId = null);
    }
}

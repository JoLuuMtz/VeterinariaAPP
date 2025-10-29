using Veterinaria.Models;

namespace Veterinaria.Interfaces
{
    public interface IHistorialMedicoRepository
    {
        Task<IEnumerable<HistorialMedico>> GetAllAsync();
        Task<HistorialMedico?> GetByIdAsync(int id);
        Task<IEnumerable<HistorialMedico>> GetByMascotaIdAsync(int mascotaId);
        Task<IEnumerable<HistorialMedico>> GetByVeterinarioIdAsync(int veterinarioId);
        Task<HistorialMedico> CreateAsync(HistorialMedico historialMedico);
        Task<HistorialMedico?> UpdateAsync(HistorialMedico historialMedico);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}

using Veterinaria.Models;

namespace Veterinaria.Interfaces
{
    public interface IMedicamentoRepository
    {
        Task<IEnumerable<Medicamento>> GetAllAsync();
        Task<Medicamento?> GetByIdAsync(int id);
        Task<IEnumerable<Medicamento>> GetByHistorialMedicoIdAsync(int historialMedicoId);
        Task<Medicamento> CreateAsync(Medicamento medicamento);
        Task<Medicamento?> UpdateAsync(Medicamento medicamento);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}

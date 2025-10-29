using Veterinaria.DTOs;
using Veterinaria.Services;

namespace Veterinaria.Interfaces
{
    public interface IHistorialMedicoService
    {
        Task<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>> GetAllAsync();
        Task<ServiceResult<HistorialMedicoResponseDTO>> GetByIdAsync(int id);
        Task<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>> GetByMascotaIdAsync(int mascotaId);
        Task<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>> GetByVeterinarioIdAsync(int veterinarioId);
        Task<ServiceResult<HistorialMedicoResponseDTO>> CreateAsync(HistorialMedicoCreateDTO historialMedicoCreateDTO);
        Task<ServiceResult<HistorialMedicoResponseDTO>> UpdateAsync(int id, HistorialMedicoUpdateDTO historialMedicoUpdateDTO);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}

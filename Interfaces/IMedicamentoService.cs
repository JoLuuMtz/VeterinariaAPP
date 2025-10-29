using Veterinaria.DTOs;
using Veterinaria.Services;

namespace Veterinaria.Interfaces
{
    public interface IMedicamentoService
    {
        Task<ServiceResult<IEnumerable<MedicamentoResponseDTO>>> GetAllAsync();
        Task<ServiceResult<MedicamentoResponseDTO>> GetByIdAsync(int id);
        Task<ServiceResult<IEnumerable<MedicamentoResponseDTO>>> GetByHistorialMedicoIdAsync(int historialMedicoId);
        Task<ServiceResult<MedicamentoResponseDTO>> CreateAsync(MedicamentoCreateDTO medicamentoCreateDTO);
        Task<ServiceResult<MedicamentoResponseDTO>> UpdateAsync(int id, MedicamentoUpdateDTO medicamentoUpdateDTO);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}

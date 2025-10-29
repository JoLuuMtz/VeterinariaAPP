using Veterinaria.DTOs;
using Veterinaria.Services;

namespace Veterinaria.Interfaces
{
    public interface IMascotaService
    {
        Task<ServiceResult<IEnumerable<MascotaResponseDTO>>> GetAllAsync();
        Task<ServiceResult<MascotaResponseDTO>> GetByIdAsync(int id);
        Task<ServiceResult<IEnumerable<MascotaResponseDTO>>> GetByClienteIdAsync(int clienteId);
        Task<ServiceResult<MascotaResponseDTO>> CreateAsync(MascotaCreateDTO mascotaCreateDTO);
        Task<ServiceResult<MascotaResponseDTO>> UpdateAsync(int id, MascotaUpdateDTO mascotaUpdateDTO);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}

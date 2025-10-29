using Veterinaria.DTOs;
using Veterinaria.Services;

namespace Veterinaria.Interfaces
{
    public interface IVeterinarioService
    {
        Task<ServiceResult<IEnumerable<VeterinarioResponseDTO>>> GetAllAsync();
        Task<ServiceResult<VeterinarioResponseDTO>> GetByIdAsync(int id);
        Task<ServiceResult<VeterinarioResponseDTO>> CreateAsync(VeterinarioCreateDTO veterinarioCreateDTO);
        Task<ServiceResult<VeterinarioResponseDTO>> UpdateAsync(int id, VeterinarioUpdateDTO veterinarioUpdateDTO);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}

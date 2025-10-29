using Veterinaria.DTOs;
using Veterinaria.Services;

namespace Veterinaria.Interfaces
{
    public interface ICitaService
    {
        Task<ServiceResult<IEnumerable<CitaResponseDTO>>> GetAllAsync();
        Task<ServiceResult<CitaResponseDTO>> GetByIdAsync(int id);
        Task<ServiceResult<IEnumerable<CitaResponseDTO>>> GetByMascotaIdAsync(int mascotaId);
        Task<ServiceResult<IEnumerable<CitaResponseDTO>>> GetByVeterinarioIdAsync(int veterinarioId);
        Task<ServiceResult<IEnumerable<CitaResponseDTO>>> GetByFechaAsync(DateTime fecha);
        Task<ServiceResult<CitaResponseDTO>> CreateAsync(CitaCreateDTO citaCreateDTO);
        Task<ServiceResult<CitaResponseDTO>> UpdateAsync(int id, CitaUpdateDTO citaUpdateDTO);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}

using Veterinaria.DTOs;
using Veterinaria.Services;

namespace Veterinaria.Interfaces
{
    public interface IClienteService
    {
        Task<ServiceResult<IEnumerable<ClienteResponseDTO>>> GetAllAsync();
        Task<ServiceResult<ClienteResponseDTO>> GetByIdAsync(int id);
        Task<ServiceResult<ClienteResponseDTO>> CreateAsync(ClienteCreateDTO clienteCreateDTO);
        Task<ServiceResult<ClienteResponseDTO>> UpdateAsync(int id, ClienteUpdateDTO clienteUpdateDTO);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}

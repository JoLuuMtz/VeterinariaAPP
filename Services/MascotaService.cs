using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Services
{
    public class MascotaService : IMascotaService
    {
        private readonly IMascotaRepository _mascotaRepository;

        public MascotaService(IMascotaRepository mascotaRepository)
        {
            _mascotaRepository = mascotaRepository;
        }

        public async Task<ServiceResult<IEnumerable<MascotaResponseDTO>>> GetAllAsync()
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<MascotaResponseDTO>> GetByIdAsync(int id)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<IEnumerable<MascotaResponseDTO>>> GetByClienteIdAsync(int clienteId)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<MascotaResponseDTO>> CreateAsync(MascotaCreateDTO mascotaCreateDTO)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<MascotaResponseDTO>> UpdateAsync(int id, MascotaUpdateDTO mascotaUpdateDTO)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }
    }
}

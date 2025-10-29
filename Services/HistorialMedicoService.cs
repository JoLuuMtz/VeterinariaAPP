using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Services
{
    public class HistorialMedicoService : IHistorialMedicoService
    {
        private readonly IHistorialMedicoRepository _historialMedicoRepository;

        public HistorialMedicoService(IHistorialMedicoRepository historialMedicoRepository)
        {
            _historialMedicoRepository = historialMedicoRepository;
        }

        public async Task<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>> GetAllAsync()
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<HistorialMedicoResponseDTO>> GetByIdAsync(int id)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>> GetByMascotaIdAsync(int mascotaId)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>> GetByVeterinarioIdAsync(int veterinarioId)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<HistorialMedicoResponseDTO>> CreateAsync(HistorialMedicoCreateDTO historialMedicoCreateDTO)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<HistorialMedicoResponseDTO>> UpdateAsync(int id, HistorialMedicoUpdateDTO historialMedicoUpdateDTO)
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

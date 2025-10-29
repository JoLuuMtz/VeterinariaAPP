using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Services
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository _medicamentoRepository;

        public MedicamentoService(IMedicamentoRepository medicamentoRepository)
        {
            _medicamentoRepository = medicamentoRepository;
        }

        public async Task<ServiceResult<IEnumerable<MedicamentoResponseDTO>>> GetAllAsync()
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<MedicamentoResponseDTO>> GetByIdAsync(int id)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<IEnumerable<MedicamentoResponseDTO>>> GetByHistorialMedicoIdAsync(int historialMedicoId)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<MedicamentoResponseDTO>> CreateAsync(MedicamentoCreateDTO medicamentoCreateDTO)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<MedicamentoResponseDTO>> UpdateAsync(int id, MedicamentoUpdateDTO medicamentoUpdateDTO)
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

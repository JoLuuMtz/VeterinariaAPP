using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Services
{
    public class VeterinarioService : IVeterinarioService
    {
        private readonly IVeterinarioRepository _veterinarioRepository;

        public VeterinarioService(IVeterinarioRepository veterinarioRepository)
        {
            _veterinarioRepository = veterinarioRepository;
        }

        public async Task<ServiceResult<IEnumerable<VeterinarioResponseDTO>>> GetAllAsync()
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<VeterinarioResponseDTO>> GetByIdAsync(int id)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<VeterinarioResponseDTO>> CreateAsync(VeterinarioCreateDTO veterinarioCreateDTO)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<VeterinarioResponseDTO>> UpdateAsync(int id, VeterinarioUpdateDTO veterinarioUpdateDTO)
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

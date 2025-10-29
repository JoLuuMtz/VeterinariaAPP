using Veterinaria.DTOs;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ServiceResult<IEnumerable<ClienteResponseDTO>>> GetAllAsync()
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ClienteResponseDTO>> GetByIdAsync(int id)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ClienteResponseDTO>> CreateAsync(ClienteCreateDTO clienteCreateDTO)
        {
            // TODO: Implementar lógica de negocio
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ClienteResponseDTO>> UpdateAsync(int id, ClienteUpdateDTO clienteUpdateDTO)
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

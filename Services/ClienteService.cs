using Veterinaria.DTOs;
using Veterinaria.Interfaces;
using VeterinariaApp.Models;

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
            try
            {
                var clientes = await _clienteRepository.GetAllAsync();
                var clientesDTO = clientes.Select(c => MapToResponseDTO(c));
                return ServiceResult<IEnumerable<ClienteResponseDTO>>.Ok(clientesDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ClienteResponseDTO>>.Fail(
                    $"Error al obtener los clientes: {ex.Message}");
            }
        }

        public async Task<ServiceResult<ClienteResponseDTO>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<ClienteResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var cliente = await _clienteRepository.GetByIdAsync(id);
                if (cliente == null)
                    return ServiceResult<ClienteResponseDTO>.Fail("Cliente no encontrado.");

                return ServiceResult<ClienteResponseDTO>.Ok(MapToResponseDTO(cliente));
            }
            catch (Exception ex)
            {
                return ServiceResult<ClienteResponseDTO>.Fail($"Error al obtener el cliente: {ex.Message}");
            }
        }

        public async Task<ServiceResult<ClienteResponseDTO>> CreateAsync(ClienteCreateDTO clienteCreateDTO)
        {
            try
            {
                // Validar que el email no esté duplicado
                if (!string.IsNullOrWhiteSpace(clienteCreateDTO.Email))
                {
                    var emailExiste = await _clienteRepository.ExistsByEmailAsync(clienteCreateDTO.Email);
                    if (emailExiste)
                        return ServiceResult<ClienteResponseDTO>.Fail(
                            "Ya existe un cliente con este correo electrónico.");
                }

                // Validar que el documento de identidad no esté duplicado
                if (!string.IsNullOrWhiteSpace(clienteCreateDTO.DocumentoIdentidad))
                {
                    var documentoExiste =
                        await _clienteRepository.ExistsByDocumentoIdentidadAsync(clienteCreateDTO.DocumentoIdentidad);
                    if (documentoExiste)
                        return ServiceResult<ClienteResponseDTO>.Fail(
                            "Ya existe un cliente con este documento de identidad.");
                }

                // Validar que el teléfono no esté duplicado
                if (!string.IsNullOrWhiteSpace(clienteCreateDTO.Telefono))
                {
                    var telefonoExiste = await _clienteRepository.ExistsByTelefonoAsync(clienteCreateDTO.Telefono);
                    if (telefonoExiste)
                        return ServiceResult<ClienteResponseDTO>.Fail(
                            "Ya existe un cliente con este número de teléfono.");
                }

                var cliente = new Cliente
                {
                    Nombre = clienteCreateDTO.Nombre,
                    Apellido = clienteCreateDTO.Apellido,
                    Telefono = clienteCreateDTO.Telefono,
                    Email = clienteCreateDTO.Email,
                    DocumentoIdentidad = clienteCreateDTO.DocumentoIdentidad,
                    Direccion = clienteCreateDTO.Direccion,
                    FechaRegistro = DateTime.Now,
                    Activo = true
                };

                var clienteCreado = await _clienteRepository.CreateAsync(cliente);
                return ServiceResult<ClienteResponseDTO>.Ok(MapToResponseDTO(clienteCreado));
            }
            catch (Exception ex)
            {
                return ServiceResult<ClienteResponseDTO>.Fail($"Error al crear el cliente: {ex.Message}");
            }
        }

        public async Task<ServiceResult<ClienteResponseDTO>> UpdateAsync(int id, ClienteUpdateDTO clienteUpdateDTO)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<ClienteResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var cliente = await _clienteRepository.GetByIdAsync(id);
                if (cliente == null)
                    return ServiceResult<ClienteResponseDTO>.Fail("Cliente no encontrado.");

                // Validar que el email no esté duplicado (excluyendo el cliente actual)
                if (!string.IsNullOrWhiteSpace(clienteUpdateDTO.Email))
                {
                    var emailExiste = await _clienteRepository.ExistsByEmailAsync(clienteUpdateDTO.Email, id);
                    if (emailExiste)
                        return ServiceResult<ClienteResponseDTO>.Fail(
                            "Ya existe otro cliente con este correo electrónico.");
                }

                // Validar que el documento de identidad no esté duplicado (excluyendo el cliente actual)
                if (!string.IsNullOrWhiteSpace(clienteUpdateDTO.DocumentoIdentidad))
                {
                    var documentoExiste =
                        await _clienteRepository.ExistsByDocumentoIdentidadAsync(clienteUpdateDTO.DocumentoIdentidad,
                            id);
                    if (documentoExiste)
                        return ServiceResult<ClienteResponseDTO>.Fail(
                            "Ya existe otro cliente con este documento de identidad.");
                }

                // Validar que el teléfono no esté duplicado (excluyendo el cliente actual)
                if (!string.IsNullOrWhiteSpace(clienteUpdateDTO.Telefono))
                {
                    var telefonoExiste = await _clienteRepository.ExistsByTelefonoAsync(clienteUpdateDTO.Telefono, id);
                    if (telefonoExiste)
                        return ServiceResult<ClienteResponseDTO>.Fail(
                            "Ya existe otro cliente con este número de teléfono.");
                }

                // Actualización parcial: solo actualizar campos que no sean null
                if (clienteUpdateDTO.Nombre != null)
                    cliente.Nombre = clienteUpdateDTO.Nombre;
                if (clienteUpdateDTO.Apellido != null)
                    cliente.Apellido = clienteUpdateDTO.Apellido;
                if (clienteUpdateDTO.Telefono != null)
                    cliente.Telefono = clienteUpdateDTO.Telefono;
                if (clienteUpdateDTO.Email != null)
                    cliente.Email = clienteUpdateDTO.Email;
                if (clienteUpdateDTO.DocumentoIdentidad != null)
                    cliente.DocumentoIdentidad = clienteUpdateDTO.DocumentoIdentidad;
                if (clienteUpdateDTO.Direccion != null)
                    cliente.Direccion = clienteUpdateDTO.Direccion;
                if (clienteUpdateDTO.Activo.HasValue)
                    cliente.Activo = clienteUpdateDTO.Activo.Value;

                var clienteActualizado = await _clienteRepository.UpdateAsync(cliente);
                if (clienteActualizado == null)
                    return ServiceResult<ClienteResponseDTO>.Fail("Error al actualizar el cliente.");

                return ServiceResult<ClienteResponseDTO>.Ok(MapToResponseDTO(clienteActualizado));
            }
            catch (Exception ex)
            {
                return ServiceResult<ClienteResponseDTO>.Fail($"Error al actualizar el cliente: {ex.Message}");
            }
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<bool>.Fail("El ID debe ser mayor a 0.");

                var existe = await _clienteRepository.ExistsAsync(id);
                if (!existe)
                    return ServiceResult<bool>.Fail("Cliente no encontrado.");

                var resultado = await _clienteRepository.DeleteAsync(id);
                if (!resultado)
                    return ServiceResult<bool>.Fail("Error al eliminar el cliente.");

                return ServiceResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail($"Error al eliminar el cliente: {ex.Message}");
            }
        }

        private static ClienteResponseDTO MapToResponseDTO(Cliente cliente)
        {
            return new ClienteResponseDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                DocumentoIdentidad = cliente.DocumentoIdentidad,
                Direccion = cliente.Direccion,
                FechaRegistro = cliente.FechaRegistro,
                Activo = cliente.Activo
            };
        }
    }
}

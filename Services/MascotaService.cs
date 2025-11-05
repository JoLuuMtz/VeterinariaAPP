using Veterinaria.DTOs;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services
{
    public class MascotaService : IMascotaService
    {
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IClienteRepository _clienteRepository;

        public MascotaService(IMascotaRepository mascotaRepository, IClienteRepository clienteRepository)
        {
            _mascotaRepository = mascotaRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<ServiceResult<IEnumerable<MascotaResponseDTO>>> GetAllAsync()
        {
            try
            {
                var mascotas = await _mascotaRepository.GetAllAsync();
                var mascotasDTO = mascotas.Select(m => MapToResponseDTO(m));
                return ServiceResult<IEnumerable<MascotaResponseDTO>>.Ok(mascotasDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<MascotaResponseDTO>>.Fail(
                    $"Error al obtener las mascotas: {ex.Message}");
            }
        }

        public async Task<ServiceResult<MascotaResponseDTO>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<MascotaResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var mascota = await _mascotaRepository.GetByIdAsync(id);
                if (mascota == null)
                    return ServiceResult<MascotaResponseDTO>.Fail("Mascota no encontrada.");

                return ServiceResult<MascotaResponseDTO>.Ok(MapToResponseDTO(mascota));
            }
            catch (Exception ex)
            {
                return ServiceResult<MascotaResponseDTO>.Fail($"Error al obtener la mascota: {ex.Message}");
            }
        }

        public async Task<ServiceResult<IEnumerable<MascotaResponseDTO>>> GetByClienteIdAsync(int clienteId)
        {
            try
            {
                if (clienteId <= 0)
                    return ServiceResult<IEnumerable<MascotaResponseDTO>>.Fail("El ID del cliente debe ser mayor a 0.");

                var mascotas = await _mascotaRepository.GetByClienteIdAsync(clienteId);
                var mascotasDTO = mascotas.Select(m => MapToResponseDTO(m));
                return ServiceResult<IEnumerable<MascotaResponseDTO>>.Ok(mascotasDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<MascotaResponseDTO>>.Fail(
                    $"Error al obtener las mascotas del cliente: {ex.Message}");
            }
        }

        public async Task<ServiceResult<MascotaResponseDTO>> CreateAsync(MascotaCreateDTO mascotaCreateDTO)
        {
            try
            {
                // Validar que el cliente exista si se proporciona ClienteId
                if (mascotaCreateDTO.ClienteId.HasValue)
                {
                    var clienteExiste = await _clienteRepository.ExistsAsync(mascotaCreateDTO.ClienteId.Value);
                    if (!clienteExiste)
                        return ServiceResult<MascotaResponseDTO>.Fail("El cliente especificado no existe.");
                }

                var mascota = new Mascota
                {
                    Nombre = mascotaCreateDTO.Nombre,
                    Especie = mascotaCreateDTO.Especie,
                    Raza = mascotaCreateDTO.Raza,
                    FechaNacimiento = mascotaCreateDTO.FechaNacimiento,
                    Sexo = mascotaCreateDTO.Sexo,
                    Color = mascotaCreateDTO.Color,
                    Peso = mascotaCreateDTO.Peso,
                    Observaciones = mascotaCreateDTO.Observaciones,
                    ClienteId = mascotaCreateDTO.ClienteId,
                    Activo = true
                };

                var mascotaCreada = await _mascotaRepository.CreateAsync(mascota);
                return ServiceResult<MascotaResponseDTO>.Ok(MapToResponseDTO(mascotaCreada));
            }
            catch (Exception ex)
            {
                return ServiceResult<MascotaResponseDTO>.Fail($"Error al crear la mascota: {ex.Message}");
            }
        }

        public async Task<ServiceResult<MascotaResponseDTO>> UpdateAsync(int id, MascotaUpdateDTO mascotaUpdateDTO)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<MascotaResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var mascota = await _mascotaRepository.GetByIdAsync(id);
                if (mascota == null)
                    return ServiceResult<MascotaResponseDTO>.Fail("Mascota no encontrada.");

                // Validar que el cliente exista si se proporciona un nuevo ClienteId a la mascota
                if (mascotaUpdateDTO.ClienteId.HasValue)
                {
                    var clienteExiste = await _clienteRepository.ExistsAsync(mascotaUpdateDTO.ClienteId.Value);
                    if (!clienteExiste)
                        return ServiceResult<MascotaResponseDTO>.Fail("El cliente especificado no existe.");
                }

                mascota.Nombre = mascotaUpdateDTO.Nombre;
                mascota.Especie = mascotaUpdateDTO.Especie;
                mascota.Raza = mascotaUpdateDTO.Raza;
                mascota.FechaNacimiento = mascotaUpdateDTO.FechaNacimiento;
                mascota.Sexo = mascotaUpdateDTO.Sexo;
                mascota.Color = mascotaUpdateDTO.Color;
                mascota.Peso = mascotaUpdateDTO.Peso;
                mascota.Observaciones = mascotaUpdateDTO.Observaciones;
                mascota.Activo = mascotaUpdateDTO.Activo;
                mascota.ClienteId = mascotaUpdateDTO.ClienteId; // Actualizar el ClienteId para asignar a otro cliente

                var mascotaActualizada = await _mascotaRepository.UpdateAsync(mascota);
                if (mascotaActualizada == null)
                    return ServiceResult<MascotaResponseDTO>.Fail("Error al actualizar la mascota.");

                return ServiceResult<MascotaResponseDTO>.Ok(MapToResponseDTO(mascotaActualizada));
            }
            catch (Exception ex)
            {
                return ServiceResult<MascotaResponseDTO>.Fail($"Error al actualizar la mascota: {ex.Message}");
            }
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<bool>.Fail("El ID debe ser mayor a 0.");

                var existe = await _mascotaRepository.ExistsAsync(id);
                if (!existe)
                    return ServiceResult<bool>.Fail("Mascota no encontrada.");

                var resultado = await _mascotaRepository.DeleteAsync(id);
                if (!resultado)
                    return ServiceResult<bool>.Fail("Error al eliminar la mascota.");

                return ServiceResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail($"Error al eliminar la mascota: {ex.Message}");
            }
        }

        private static MascotaResponseDTO MapToResponseDTO(Mascota mascota)
        {
            return new MascotaResponseDTO
            {
                Id = mascota.Id,
                Nombre = mascota.Nombre,
                Especie = mascota.Especie,
                Raza = mascota.Raza,
                FechaNacimiento = mascota.FechaNacimiento,
                Sexo = mascota.Sexo,
                Color = mascota.Color,
                Peso = mascota.Peso,
                Observaciones = mascota.Observaciones,
                Activo = mascota.Activo,
                ClienteId = mascota.ClienteId ?? 0,
                ClienteNombre = mascota.Cliente != null ? $"{mascota.Cliente.Nombre} {mascota.Cliente.Apellido}" : null
            };
        }
    }
}

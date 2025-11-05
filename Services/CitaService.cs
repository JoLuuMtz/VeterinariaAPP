using Veterinaria.DTOs;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IVeterinarioRepository _veterinarioRepository;

        public CitaService(
            ICitaRepository citaRepository,
            IMascotaRepository mascotaRepository,
            IVeterinarioRepository veterinarioRepository
        )
        {
            _citaRepository = citaRepository;
            _mascotaRepository = mascotaRepository;
            _veterinarioRepository = veterinarioRepository;
        }

        // Obtener todas la citas    
        public async Task<ServiceResult<IEnumerable<CitaResponseDTO>>> GetAllAsync()
        {
            try
            {
                var citas = await _citaRepository.GetAllAsync();
                var citasDTO = citas.Select(c => MapToResponseDTO(c));
                return ServiceResult<IEnumerable<CitaResponseDTO>>.Ok(citasDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<CitaResponseDTO>>.Fail($"Error al obtener las citas: {ex.Message}");
            }
        }

        // Obtener una cita por su id
        public async Task<ServiceResult<CitaResponseDTO>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<CitaResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var cita = await _citaRepository.GetByIdAsync(id);
                if (cita is null)
                    return ServiceResult<CitaResponseDTO>.Fail("Cita no encontrada. verifique el id");

                return ServiceResult<CitaResponseDTO>.Ok(MapToResponseDTO(cita));
            }
            catch (Exception ex)
            {
                return ServiceResult<CitaResponseDTO>.Fail($"Error al obtener la cita: {ex.Message}");
            }
        }

        public async Task<ServiceResult<IEnumerable<CitaResponseDTO>>> GetByMascotaIdAsync(int mascotaId)
        {
            try
            {
                if (mascotaId <= 0)
                    return ServiceResult<IEnumerable<CitaResponseDTO>>.Fail("El ID de la mascota debe ser mayor a 0.");

                var citas = await _citaRepository.GetByMascotaIdAsync(mascotaId);
                var citasDTO = citas.Select(c => MapToResponseDTO(c));
                return ServiceResult<IEnumerable<CitaResponseDTO>>.Ok(citasDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<CitaResponseDTO>>.Fail(
                    $"Error al obtener las citas de la mascota: {ex.Message}");
            }
        }

        public async Task<ServiceResult<IEnumerable<CitaResponseDTO>>> GetByVeterinarioIdAsync(int veterinarioId)
        {
            try
            {
                if (veterinarioId <= 0)
                    return ServiceResult<IEnumerable<CitaResponseDTO>>.Fail(
                        "El ID del veterinario debe ser mayor a 0.");

                var citas = await _citaRepository.GetByVeterinarioIdAsync(veterinarioId);
                var citasDTO = citas.Select(c => MapToResponseDTO(c));
                return ServiceResult<IEnumerable<CitaResponseDTO>>.Ok(citasDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<CitaResponseDTO>>.Fail(
                    $"Error al obtener las citas del veterinario: {ex.Message}");
            }
        }

        public async Task<ServiceResult<IEnumerable<CitaResponseDTO>>> GetByFechaAsync(DateTime fecha)
        {
            try
            {
                var citas = await _citaRepository.GetByFechaAsync(fecha);
                var citasDTO = citas.Select(c => MapToResponseDTO(c));
                return ServiceResult<IEnumerable<CitaResponseDTO>>.Ok(citasDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<CitaResponseDTO>>.Fail(
                    $"Error al obtener las citas por fecha: {ex.Message}");
            }
        }

        public async Task<ServiceResult<CitaResponseDTO>> CreateAsync(CitaCreateDTO citaCreateDTO)
        {
            try
            {
                // Validar que la mascota exista
                var mascotaExiste = await _mascotaRepository.ExistsAsync(citaCreateDTO.MascotaId);
                if (!mascotaExiste)
                    return ServiceResult<CitaResponseDTO>.Fail("La mascota especificada no existe.");

                // Validar que el veterinario exista
                var veterinarioExiste = await _veterinarioRepository.ExistsAsync(citaCreateDTO.VeterinarioId);
                if (!veterinarioExiste)
                    return ServiceResult<CitaResponseDTO>.Fail("El veterinario especificado no existe.");

                //todo: Mapear con automapper
                var cita = new Cita
                {
                    FechaHora = citaCreateDTO.FechaHora,
                    Estado = citaCreateDTO.Estado,
                    Motivo = citaCreateDTO.Motivo,
                    Observaciones = citaCreateDTO.Observaciones,
                    MascotaId = citaCreateDTO.MascotaId,
                    VeterinarioId = citaCreateDTO.VeterinarioId
                };

                var citaCreada = await _citaRepository.CreateAsync(cita);
                return ServiceResult<CitaResponseDTO>.Ok(MapToResponseDTO(citaCreada));
            }
            catch (Exception ex)
            {
                return ServiceResult<CitaResponseDTO>.Fail($"Error al crear la cita: {ex.Message}");
            }
        }

        public async Task<ServiceResult<CitaResponseDTO>> UpdateAsync(int id, CitaUpdateDTO citaUpdateDTO)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<CitaResponseDTO>.Fail("El ID debe ser mayor a 0. verifique el id");

                var cita = await _citaRepository.GetByIdAsync(id);
                if (cita is null)
                    return ServiceResult<CitaResponseDTO>.Fail("Cita no encontrada.");

                cita.FechaHora = citaUpdateDTO.FechaHora;
                cita.Estado = citaUpdateDTO.Estado;
                cita.Motivo = citaUpdateDTO.Motivo;
                cita.Observaciones = citaUpdateDTO.Observaciones;

                var citaActualizada = await _citaRepository.UpdateAsync(cita);
                if (citaActualizada is null)
                    return ServiceResult<CitaResponseDTO>.Fail("Error al actualizar la cita.");

                return ServiceResult<CitaResponseDTO>.Ok(MapToResponseDTO(citaActualizada));
            }
            catch (Exception ex)
            {
                return ServiceResult<CitaResponseDTO>.Fail($"Error al actualizar la cita: {ex.Message}");
            }
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<bool>.Fail("El ID debe ser mayor a 0.");

                var existe = await _citaRepository.ExistsAsync(id);
                if (!existe)
                    return ServiceResult<bool>.Fail("Cita no encontrada.");

                var resultado = await _citaRepository.DeleteAsync(id);
                if (!resultado)
                    return ServiceResult<bool>.Fail("Error al eliminar la cita.");

                return ServiceResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail($"Error al eliminar la cita: {ex.Message}");
            }
        }

        private static CitaResponseDTO MapToResponseDTO(Cita cita)
        {
            return new CitaResponseDTO
            {
                Id = cita.Id,
                FechaHora = cita.FechaHora,
                Estado = cita.Estado,
                Motivo = cita.Motivo,
                Observaciones = cita.Observaciones,
                MascotaId = cita.MascotaId,
                MascotaNombre = cita.Mascota?.Nombre ?? "N/A",
                VeterinarioId = cita.VeterinarioId,
                VeterinarioNombre = cita.Veterinario != null
                    ? $"{cita.Veterinario.Nombre} {cita.Veterinario.Apellido}"
                    : "N/A"
            };
        }
    }
}

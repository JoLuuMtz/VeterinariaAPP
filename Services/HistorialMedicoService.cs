using Veterinaria.DTOs;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services
{
    public class HistorialMedicoService : IHistorialMedicoService
    {
        private readonly IHistorialMedicoRepository _historialMedicoRepository;
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IVeterinarioRepository _veterinarioRepository;

        public HistorialMedicoService(
            IHistorialMedicoRepository historialMedicoRepository,
            IMascotaRepository mascotaRepository,
            IVeterinarioRepository veterinarioRepository)
        {
            _historialMedicoRepository = historialMedicoRepository;
            _mascotaRepository = mascotaRepository;
            _veterinarioRepository = veterinarioRepository;
        }

        public async Task<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>> GetAllAsync()
        {
            try
            {
                var historiales = await _historialMedicoRepository.GetAllAsync();
                var historialesDTO = historiales.Select(h => MapToResponseDTO(h));
                return ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>.Ok(historialesDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>.Fail(
                    $"Error al obtener los historiales médicos: {ex.Message}");
            }
        }

        public async Task<ServiceResult<HistorialMedicoResponseDTO>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<HistorialMedicoResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var historial = await _historialMedicoRepository.GetByIdAsync(id);
                if (historial == null)
                    return ServiceResult<HistorialMedicoResponseDTO>.Fail("Historial médico no encontrado.");

                return ServiceResult<HistorialMedicoResponseDTO>.Ok(MapToResponseDTO(historial));
            }
            catch (Exception ex)
            {
                return ServiceResult<HistorialMedicoResponseDTO>.Fail(
                    $"Error al obtener el historial médico: {ex.Message}");
            }
        }

        public async Task<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>> GetByMascotaIdAsync(int mascotaId)
        {
            try
            {
                if (mascotaId <= 0)
                    return ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>.Fail(
                        "El ID de la mascota debe ser mayor a 0.");

                var historiales = await _historialMedicoRepository.GetByMascotaIdAsync(mascotaId);
                var historialesDTO = historiales.Select(h => MapToResponseDTO(h));
                return ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>.Ok(historialesDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>.Fail(
                    $"Error al obtener los historiales médicos de la mascota: {ex.Message}");
            }
        }

        public async Task<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>> GetByVeterinarioIdAsync(
            int veterinarioId)
        {
            try
            {
                if (veterinarioId <= 0)
                    return ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>.Fail(
                        "El ID del veterinario debe ser mayor a 0.");

                var historiales = await _historialMedicoRepository.GetByVeterinarioIdAsync(veterinarioId);
                var historialesDTO = historiales.Select(h => MapToResponseDTO(h));
                return ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>.Ok(historialesDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>.Fail(
                    $"Error al obtener los historiales médicos del veterinario: {ex.Message}");
            }
        }

        public async Task<ServiceResult<HistorialMedicoResponseDTO>> CreateAsync(
            HistorialMedicoCreateDTO historialMedicoCreateDTO)
        {
            try
            {
                // Validar que la mascota exista
                var mascotaExiste = await _mascotaRepository.ExistsAsync(historialMedicoCreateDTO.MascotaId);
                if (!mascotaExiste)
                    return ServiceResult<HistorialMedicoResponseDTO>.Fail("La mascota especificada no existe.");

                // Validar que el veterinario exista
                var veterinarioExiste =
                    await _veterinarioRepository.ExistsAsync(historialMedicoCreateDTO.VeterinarioId);
                if (!veterinarioExiste)
                    return ServiceResult<HistorialMedicoResponseDTO>.Fail("El veterinario especificado no existe.");

                var historialMedico = new HistorialMedico
                {
                    Fecha = historialMedicoCreateDTO.Fecha,
                    TipoConsulta = historialMedicoCreateDTO.TipoConsulta,
                    Diagnostico = historialMedicoCreateDTO.Diagnostico,
                    Tratamiento = historialMedicoCreateDTO.Tratamiento,
                    Observaciones = historialMedicoCreateDTO.Observaciones,
                    PesoRegistrado = historialMedicoCreateDTO.PesoRegistrado,
                    Temperatura = historialMedicoCreateDTO.Temperatura,
                    MascotaId = historialMedicoCreateDTO.MascotaId,
                    VeterinarioId = historialMedicoCreateDTO.VeterinarioId
                };

                var historialCreado = await _historialMedicoRepository.CreateAsync(historialMedico);
                return ServiceResult<HistorialMedicoResponseDTO>.Ok(MapToResponseDTO(historialCreado));
            }
            catch (Exception ex)
            {
                return ServiceResult<HistorialMedicoResponseDTO>.Fail(
                    $"Error al crear el historial médico: {ex.Message}");
            }
        }

        public async Task<ServiceResult<HistorialMedicoResponseDTO>> UpdateAsync(int id,
            HistorialMedicoUpdateDTO historialMedicoUpdateDTO)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<HistorialMedicoResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var historial = await _historialMedicoRepository.GetByIdAsync(id);
                if (historial == null)
                    return ServiceResult<HistorialMedicoResponseDTO>.Fail("Historial médico no encontrado.");

                historial.Fecha = historialMedicoUpdateDTO.Fecha;
                historial.TipoConsulta = historialMedicoUpdateDTO.TipoConsulta;
                historial.Diagnostico = historialMedicoUpdateDTO.Diagnostico;
                historial.Tratamiento = historialMedicoUpdateDTO.Tratamiento;
                historial.Observaciones = historialMedicoUpdateDTO.Observaciones;
                historial.PesoRegistrado = historialMedicoUpdateDTO.PesoRegistrado;
                historial.Temperatura = historialMedicoUpdateDTO.Temperatura;

                var historialActualizado = await _historialMedicoRepository.UpdateAsync(historial);
                if (historialActualizado == null)
                    return ServiceResult<HistorialMedicoResponseDTO>.Fail("Error al actualizar el historial médico.");

                return ServiceResult<HistorialMedicoResponseDTO>.Ok(MapToResponseDTO(historialActualizado));
            }
            catch (Exception ex)
            {
                return ServiceResult<HistorialMedicoResponseDTO>.Fail(
                    $"Error al actualizar el historial médico: {ex.Message}");
            }
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<bool>.Fail("El ID debe ser mayor a 0.");

                var existe = await _historialMedicoRepository.ExistsAsync(id);
                if (!existe)
                    return ServiceResult<bool>.Fail("Historial médico no encontrado.");

                var resultado = await _historialMedicoRepository.DeleteAsync(id);
                if (!resultado)
                    return ServiceResult<bool>.Fail("Error al eliminar el historial médico.");

                return ServiceResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail($"Error al eliminar el historial médico: {ex.Message}");
            }
        }

        private static HistorialMedicoResponseDTO MapToResponseDTO(HistorialMedico historial)
        {
            return new HistorialMedicoResponseDTO
            {
                Id = historial.Id,
                Fecha = historial.Fecha,
                TipoConsulta = historial.TipoConsulta,
                Diagnostico = historial.Diagnostico,
                Tratamiento = historial.Tratamiento,
                Observaciones = historial.Observaciones,
                PesoRegistrado = historial.PesoRegistrado,
                Temperatura = historial.Temperatura,
                MascotaId = historial.MascotaId,
                MascotaNombre = historial.Mascota?.Nombre ?? "N/A",
                VeterinarioId = historial.VeterinarioId,
                VeterinarioNombre = historial.Veterinario != null
                    ? $"{historial.Veterinario.Nombre} {historial.Veterinario.Apellido}"
                    : "N/A"
            };
        }
    }
}

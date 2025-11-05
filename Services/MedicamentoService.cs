using Veterinaria.DTOs;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository _medicamentoRepository;
        private readonly IHistorialMedicoRepository _historialMedicoRepository;

        public MedicamentoService(IMedicamentoRepository medicamentoRepository,
            IHistorialMedicoRepository historialMedicoRepository)
        {
            _medicamentoRepository = medicamentoRepository;
            _historialMedicoRepository = historialMedicoRepository;
        }

        public async Task<ServiceResult<IEnumerable<MedicamentoResponseDTO>>> GetAllAsync()
        {
            try
            {
                var medicamentos = await _medicamentoRepository.GetAllAsync();
                var medicamentosDTO = medicamentos.Select(m => MapToResponseDTO(m));
                return ServiceResult<IEnumerable<MedicamentoResponseDTO>>.Ok(medicamentosDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<MedicamentoResponseDTO>>.Fail(
                    $"Error al obtener los medicamentos: {ex.Message}");
            }
        }

        public async Task<ServiceResult<MedicamentoResponseDTO>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<MedicamentoResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var medicamento = await _medicamentoRepository.GetByIdAsync(id);
                if (medicamento == null)
                    return ServiceResult<MedicamentoResponseDTO>.Fail("Medicamento no encontrado.");

                return ServiceResult<MedicamentoResponseDTO>.Ok(MapToResponseDTO(medicamento));
            }
            catch (Exception ex)
            {
                return ServiceResult<MedicamentoResponseDTO>.Fail($"Error al obtener el medicamento: {ex.Message}");
            }
        }

        public async Task<ServiceResult<IEnumerable<MedicamentoResponseDTO>>> GetByHistorialMedicoIdAsync(
            int historialMedicoId)
        {
            try
            {
                if (historialMedicoId <= 0)
                    return ServiceResult<IEnumerable<MedicamentoResponseDTO>>.Fail(
                        "El ID del historial médico debe ser mayor a 0.");

                var medicamentos = await _medicamentoRepository.GetByHistorialMedicoIdAsync(historialMedicoId);
                var medicamentosDTO = medicamentos.Select(m => MapToResponseDTO(m));
                return ServiceResult<IEnumerable<MedicamentoResponseDTO>>.Ok(medicamentosDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<MedicamentoResponseDTO>>.Fail(
                    $"Error al obtener los medicamentos del historial médico: {ex.Message}");
            }
        }

        public async Task<ServiceResult<MedicamentoResponseDTO>> CreateAsync(MedicamentoCreateDTO medicamentoCreateDTO)
        {
            try
            {
                // Validar que el historial médico exista
                var historialExiste =
                    await _historialMedicoRepository.ExistsAsync(medicamentoCreateDTO.HistorialMedicoId);
                if (!historialExiste)
                    return ServiceResult<MedicamentoResponseDTO>.Fail("El historial médico especificado no existe.");

                var medicamento = new Medicamento
                {
                    Nombre = medicamentoCreateDTO.Nombre,
                    Descripcion = medicamentoCreateDTO.Descripcion,
                    Dosis = medicamentoCreateDTO.Dosis,
                    Frecuencia = medicamentoCreateDTO.Frecuencia,
                    DuracionDias = medicamentoCreateDTO.DuracionDias,
                    HistorialMedicoId = medicamentoCreateDTO.HistorialMedicoId
                };

                var medicamentoCreado = await _medicamentoRepository.CreateAsync(medicamento);
                return ServiceResult<MedicamentoResponseDTO>.Ok(MapToResponseDTO(medicamentoCreado));
            }
            catch (Exception ex)
            {
                return ServiceResult<MedicamentoResponseDTO>.Fail($"Error al crear el medicamento: {ex.Message}");
            }
        }

        public async Task<ServiceResult<MedicamentoResponseDTO>> UpdateAsync(int id,
            MedicamentoUpdateDTO medicamentoUpdateDTO)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<MedicamentoResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var medicamento = await _medicamentoRepository.GetByIdAsync(id);
                if (medicamento == null)
                    return ServiceResult<MedicamentoResponseDTO>.Fail("Medicamento no encontrado.");

                // Actualización parcial: solo actualizar campos que no sean null
                if (medicamentoUpdateDTO.Nombre != null)
                    medicamento.Nombre = medicamentoUpdateDTO.Nombre;
                if (medicamentoUpdateDTO.Descripcion != null)
                    medicamento.Descripcion = medicamentoUpdateDTO.Descripcion;
                if (medicamentoUpdateDTO.Dosis != null)
                    medicamento.Dosis = medicamentoUpdateDTO.Dosis;
                if (medicamentoUpdateDTO.Frecuencia != null)
                    medicamento.Frecuencia = medicamentoUpdateDTO.Frecuencia;
                if (medicamentoUpdateDTO.DuracionDias.HasValue)
                    medicamento.DuracionDias = medicamentoUpdateDTO.DuracionDias.Value;

                var medicamentoActualizado = await _medicamentoRepository.UpdateAsync(medicamento);
                if (medicamentoActualizado == null)
                    return ServiceResult<MedicamentoResponseDTO>.Fail("Error al actualizar el medicamento.");

                return ServiceResult<MedicamentoResponseDTO>.Ok(MapToResponseDTO(medicamentoActualizado));
            }
            catch (Exception ex)
            {
                return ServiceResult<MedicamentoResponseDTO>.Fail($"Error al actualizar el medicamento: {ex.Message}");
            }
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<bool>.Fail("El ID debe ser mayor a 0.");

                var existe = await _medicamentoRepository.ExistsAsync(id);
                if (!existe)
                    return ServiceResult<bool>.Fail("Medicamento no encontrado.");

                var resultado = await _medicamentoRepository.DeleteAsync(id);
                if (!resultado)
                    return ServiceResult<bool>.Fail("Error al eliminar el medicamento.");

                return ServiceResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail($"Error al eliminar el medicamento: {ex.Message}");
            }
        }

        private static MedicamentoResponseDTO MapToResponseDTO(Medicamento medicamento)
        {
            return new MedicamentoResponseDTO
            {
                Id = medicamento.Id,
                Nombre = medicamento.Nombre,
                Descripcion = medicamento.Descripcion,
                Dosis = medicamento.Dosis,
                Frecuencia = medicamento.Frecuencia,
                DuracionDias = medicamento.DuracionDias,
                HistorialMedicoId = medicamento.HistorialMedicoId
            };
        }
    }
}

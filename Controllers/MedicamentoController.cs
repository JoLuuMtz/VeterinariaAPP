using Microsoft.AspNetCore.Mvc;
using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    /// <summary>
    /// Controlador para gestionar medicamentos de la veterinaria
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoService _medicamentoService;

        public MedicamentoController(IMedicamentoService medicamentoService)
        {
            _medicamentoService = medicamentoService;
        }

        /// <summary>
        /// Obtiene todos los medicamentos
        /// </summary>
        /// <returns>Lista de medicamentos</returns>
        /// <response code="200">Retorna la lista de medicamentos exitosamente</response>
        /// <response code="400">Si hubo un error al obtener los medicamentos</response>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<IEnumerable<MedicamentoResponseDTO>>>> GetAll()
        {
            var result = await _medicamentoService.GetAllAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene un medicamento por su ID
        /// </summary>
        /// <param name="id">ID del medicamento</param>
        /// <returns>Medicamento encontrado</returns>
        /// <response code="200">Retorna el medicamento exitosamente</response>
        /// <response code="400">Si el medicamento no fue encontrado o hubo un error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<MedicamentoResponseDTO>>> GetById(int id)
        {
            var result = await _medicamentoService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene todos los medicamentos de un historial médico
        /// </summary>
        /// <param name="historialMedicoId">ID del historial médico</param>
        /// <returns>Lista de medicamentos del historial médico</returns>
        /// <response code="200">Retorna la lista de medicamentos exitosamente</response>
        /// <response code="400">Si hubo un error al obtener los medicamentos</response>
        [HttpGet("historial/{historialMedicoId}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<MedicamentoResponseDTO>>>> GetByHistorialMedicoId(
            int historialMedicoId)
        {
            var result = await _medicamentoService.GetByHistorialMedicoIdAsync(historialMedicoId);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Crea un nuevo medicamento
        /// </summary>
        /// <param name="medicamentoCreateDTO">Datos del medicamento a crear</param>
        /// <returns>Medicamento creado</returns>
        /// <response code="201">Medicamento creado exitosamente</response>
        /// <response code="400">Si hubo un error en la validación o creación</response>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<MedicamentoResponseDTO>>> Create(
            [FromBody] MedicamentoCreateDTO medicamentoCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _medicamentoService.CreateAsync(medicamentoCreateDTO);
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Actualiza un medicamento existente
        /// </summary>
        /// <param name="id">ID del medicamento a actualizar</param>
        /// <param name="medicamentoUpdateDTO">Datos actualizados del medicamento</param>
        /// <returns>Medicamento actualizado</returns>
        /// <response code="200">Medicamento actualizado exitosamente</response>
        /// <response code="400">Si el medicamento no fue encontrado o hubo un error</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<MedicamentoResponseDTO>>> Update(int id,
            [FromBody] MedicamentoUpdateDTO medicamentoUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _medicamentoService.UpdateAsync(id, medicamentoUpdateDTO);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Elimina un medicamento
        /// </summary>
        /// <param name="id">ID del medicamento a eliminar</param>
        /// <returns>Resultado de la eliminación</returns>
        /// <response code="200">Medicamento eliminado exitosamente</response>
        /// <response code="400">Si el medicamento no fue encontrado o hubo un error</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<bool>>> Delete(int id)
        {
            var result = await _medicamentoService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

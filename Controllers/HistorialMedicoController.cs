using Microsoft.AspNetCore.Mvc;
using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    /// <summary>
    /// Controlador para gestionar historiales médicos de las mascotas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialMedicoController : ControllerBase
    {
        private readonly IHistorialMedicoService _historialMedicoService;

        public HistorialMedicoController(IHistorialMedicoService historialMedicoService)
        {
            _historialMedicoService = historialMedicoService;
        }

        /// <summary>
        /// Obtiene todos los historiales médicos
        /// </summary>
        /// <returns>Lista de historiales médicos</returns>
        /// <response code="200">Retorna la lista de historiales médicos exitosamente</response>
        /// <response code="400">Si hubo un error al obtener los historiales médicos</response>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>>> GetAll()
        {
            var result = await _historialMedicoService.GetAllAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene un historial médico por su ID
        /// </summary>
        /// <param name="id">ID del historial médico</param>
        /// <returns>Historial médico encontrado</returns>
        /// <response code="200">Retorna el historial médico exitosamente</response>
        /// <response code="400">Si el historial médico no fue encontrado o hubo un error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<HistorialMedicoResponseDTO>>> GetById(int id)
        {
            var result = await _historialMedicoService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene todos los historiales médicos de una mascota
        /// </summary>
        /// <param name="mascotaId">ID de la mascota</param>
        /// <returns>Lista de historiales médicos de la mascota</returns>
        /// <response code="200">Retorna la lista de historiales médicos exitosamente</response>
        /// <response code="400">Si hubo un error al obtener los historiales médicos</response>
        [HttpGet("mascota/{mascotaId}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>>> GetByMascotaId(
            int mascotaId)
        {
            var result = await _historialMedicoService.GetByMascotaIdAsync(mascotaId);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene todos los historiales médicos de un veterinario
        /// </summary>
        /// <param name="veterinarioId">ID del veterinario</param>
        /// <returns>Lista de historiales médicos del veterinario</returns>
        /// <response code="200">Retorna la lista de historiales médicos exitosamente</response>
        /// <response code="400">Si hubo un error al obtener los historiales médicos</response>
        [HttpGet("veterinario/{veterinarioId}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<HistorialMedicoResponseDTO>>>> GetByVeterinarioId(
            int veterinarioId)
        {
            var result = await _historialMedicoService.GetByVeterinarioIdAsync(veterinarioId);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Crea un nuevo historial médico
        /// </summary>
        /// <param name="historialMedicoCreateDTO">Datos del historial médico a crear</param>
        /// <returns>Historial médico creado</returns>
        /// <response code="201">Historial médico creado exitosamente</response>
        /// <response code="400">Si hubo un error en la validación o creación</response>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<HistorialMedicoResponseDTO>>> Create(
            [FromBody] HistorialMedicoCreateDTO historialMedicoCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _historialMedicoService.CreateAsync(historialMedicoCreateDTO);
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Actualiza un historial médico existente
        /// </summary>
        /// <param name="id">ID del historial médico a actualizar</param>
        /// <param name="historialMedicoUpdateDTO">Datos actualizados del historial médico</param>
        /// <returns>Historial médico actualizado</returns>
        /// <response code="200">Historial médico actualizado exitosamente</response>
        /// <response code="400">Si el historial médico no fue encontrado o hubo un error</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<HistorialMedicoResponseDTO>>> Update(int id,
            [FromBody] HistorialMedicoUpdateDTO historialMedicoUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _historialMedicoService.UpdateAsync(id, historialMedicoUpdateDTO);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Elimina un historial médico
        /// </summary>
        /// <param name="id">ID del historial médico a eliminar</param>
        /// <returns>Resultado de la eliminación</returns>
        /// <response code="200">Historial médico eliminado exitosamente</response>
        /// <response code="400">Si el historial médico no fue encontrado o hubo un error</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<bool>>> Delete(int id)
        {
            var result = await _historialMedicoService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

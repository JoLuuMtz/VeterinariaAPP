using Microsoft.AspNetCore.Mvc;
using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    /// <summary>
    /// Controlador para gestionar citas de la veterinaria
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        /// <summary>
        /// Obtiene todas las citas
        /// </summary>
        /// <returns>Lista de citas</returns>
        /// <response code="200">Retorna la lista de citas exitosamente</response>
        /// <response code="400">Si hubo un error al obtener las citas</response>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<IEnumerable<CitaResponseDTO>>>> GetAll()
        {
            var result = await _citaService.GetAllAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene una cita por su ID
        /// </summary>
        /// <param name="id">ID de la cita</param>
        /// <returns>Cita encontrada</returns>
        /// <response code="200">Retorna la cita exitosamente</response>
        /// <response code="400">Si la cita no fue encontrada o hubo un error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<CitaResponseDTO>>> GetById(int id)
        {
            var result = await _citaService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene todas las citas de una mascota
        /// </summary>
        /// <param name="mascotaId">ID de la mascota</param>
        /// <returns>Lista de citas de la mascota</returns>
        /// <response code="200">Retorna la lista de citas exitosamente</response>
        /// <response code="400">Si hubo un error al obtener las citas</response>
        [HttpGet("mascota/{mascotaId}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<CitaResponseDTO>>>> GetByMascotaId(int mascotaId)
        {
            var result = await _citaService.GetByMascotaIdAsync(mascotaId);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene todas las citas de un veterinario
        /// </summary>
        /// <param name="veterinarioId">ID del veterinario</param>
        /// <returns>Lista de citas del veterinario</returns>
        /// <response code="200">Retorna la lista de citas exitosamente</response>
        /// <response code="400">Si hubo un error al obtener las citas</response>
        [HttpGet("veterinario/{veterinarioId}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<CitaResponseDTO>>>> GetByVeterinarioId(
            int veterinarioId)
        {
            var result = await _citaService.GetByVeterinarioIdAsync(veterinarioId);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene todas las citas de una fecha específica
        /// </summary>
        /// <param name="fecha">Fecha de las citas (formato: yyyy-MM-dd)</param>
        /// <returns>Lista de citas de la fecha</returns>
        /// <response code="200">Retorna la lista de citas exitosamente</response>
        /// <response code="400">Si hubo un error al obtener las citas</response>
        [HttpGet("fecha/{fecha}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<CitaResponseDTO>>>> GetByFecha(DateTime fecha)
        {
            var result = await _citaService.GetByFechaAsync(fecha);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Crea una nueva cita
        /// </summary>
        /// <param name="citaCreateDTO">Datos de la cita a crear</param>
        /// <returns>Cita creada</returns>
        /// <response code="201">Cita creada exitosamente</response>
        /// <response code="400">Si hubo un error en la validación o creación</response>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<CitaResponseDTO>>> Create([FromBody] CitaCreateDTO citaCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _citaService.CreateAsync(citaCreateDTO);
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Actualiza una cita existente
        /// </summary>
        /// <param name="id">ID de la cita a actualizar</param>
        /// <param name="citaUpdateDTO">Datos actualizados de la cita</param>
        /// <returns>Cita actualizada</returns>
        /// <response code="200">Cita actualizada exitosamente</response>
        /// <response code="400">Si la cita no fue encontrada o hubo un error</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<CitaResponseDTO>>> Update(int id,
            [FromBody] CitaUpdateDTO citaUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _citaService.UpdateAsync(id, citaUpdateDTO);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Elimina una cita
        /// </summary>
        /// <param name="id">ID de la cita a eliminar</param>
        /// <returns>Resultado de la eliminación</returns>
        /// <response code="200">Cita eliminada exitosamente</response>
        /// <response code="400">Si la cita no fue encontrada o hubo un error</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<bool>>> Delete(int id)
        {
            var result = await _citaService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

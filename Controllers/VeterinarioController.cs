using Microsoft.AspNetCore.Mvc;
using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    /// <summary>
    /// Controlador para gestionar veterinarios de la clínica
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinarioController : ControllerBase
    {
        private readonly IVeterinarioService _veterinarioService;

        public VeterinarioController(IVeterinarioService veterinarioService)
        {
            _veterinarioService = veterinarioService;
        }

        /// <summary>
        /// Obtiene todos los veterinarios
        /// </summary>
        /// <returns>Lista de veterinarios</returns>
        /// <response code="200">Retorna la lista de veterinarios exitosamente</response>
        /// <response code="400">Si hubo un error al obtener los veterinarios</response>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<IEnumerable<VeterinarioResponseDTO>>>> GetAll()
        {
            var result = await _veterinarioService.GetAllAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene un veterinario por su ID
        /// </summary>
        /// <param name="id">ID del veterinario</param>
        /// <returns>Veterinario encontrado</returns>
        /// <response code="200">Retorna el veterinario exitosamente</response>
        /// <response code="400">Si el veterinario no fue encontrado o hubo un error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<VeterinarioResponseDTO>>> GetById(int id)
        {
            var result = await _veterinarioService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Crea un nuevo veterinario
        /// </summary>
        /// <param name="veterinarioCreateDTO">Datos del veterinario a crear</param>
        /// <returns>Veterinario creado</returns>
        /// <response code="201">Veterinario creado exitosamente</response>
        /// <response code="400">Si hubo un error en la validación o creación</response>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<VeterinarioResponseDTO>>> Create(
            [FromBody] VeterinarioCreateDTO veterinarioCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _veterinarioService.CreateAsync(veterinarioCreateDTO);
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Actualiza un veterinario existente
        /// </summary>
        /// <param name="id">ID del veterinario a actualizar</param>
        /// <param name="veterinarioUpdateDTO">Datos actualizados del veterinario</param>
        /// <returns>Veterinario actualizado</returns>
        /// <response code="200">Veterinario actualizado exitosamente</response>
        /// <response code="400">Si el veterinario no fue encontrado o hubo un error</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<VeterinarioResponseDTO>>> Update(int id,
            [FromBody] VeterinarioUpdateDTO veterinarioUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _veterinarioService.UpdateAsync(id, veterinarioUpdateDTO);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Elimina un veterinario
        /// </summary>
        /// <param name="id">ID del veterinario a eliminar</param>
        /// <returns>Resultado de la eliminación</returns>
        /// <response code="200">Veterinario eliminado exitosamente</response>
        /// <response code="400">Si el veterinario no fue encontrado o hubo un error</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<bool>>> Delete(int id)
        {
            var result = await _veterinarioService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

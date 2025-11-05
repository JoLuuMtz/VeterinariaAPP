using Microsoft.AspNetCore.Mvc;
using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    /// <summary>
    /// Controlador para gestionar mascotas de la veterinaria
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;

        public MascotaController(IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        /// <summary>
        /// Obtiene todas las mascotas
        /// </summary>
        /// <returns>Lista de mascotas</returns>
        /// <response code="200">Retorna la lista de mascotas exitosamente</response>
        /// <response code="400">Si hubo un error al obtener las mascotas</response>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<IEnumerable<MascotaResponseDTO>>>> GetAll()
        {
            var result = await _mascotaService.GetAllAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene una mascota por su ID
        /// </summary>
        /// <param name="id">ID de la mascota</param>
        /// <returns>Mascota encontrada</returns>
        /// <response code="200">Retorna la mascota exitosamente</response>
        /// <response code="400">Si la mascota no fue encontrada o hubo un error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<MascotaResponseDTO>>> GetById(int id)
        {
            var result = await _mascotaService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene todas las mascotas de un cliente
        /// </summary>
        /// <param name="clienteId">ID del cliente</param>
        /// <returns>Lista de mascotas del cliente</returns>
        /// <response code="200">Retorna la lista de mascotas exitosamente</response>
        /// <response code="400">Si hubo un error al obtener las mascotas</response>
        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<MascotaResponseDTO>>>> GetByClienteId(int clienteId)
        {
            var result = await _mascotaService.GetByClienteIdAsync(clienteId);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Crea una nueva mascota
        /// </summary>
        /// <param name="mascotaCreateDTO">Datos de la mascota a crear</param>
        /// <returns>Mascota creada</returns>
        /// <response code="201">Mascota creada exitosamente</response>
        /// <response code="400">Si hubo un error en la validación o creación</response>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<MascotaResponseDTO>>> Create(
            [FromBody] MascotaCreateDTO mascotaCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mascotaService.CreateAsync(mascotaCreateDTO);
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Actualiza una mascota existente
        /// </summary>
        /// <param name="id">ID de la mascota a actualizar</param>
        /// <param name="mascotaUpdateDTO">Datos actualizados de la mascota</param>
        /// <returns>Mascota actualizada</returns>
        /// <response code="200">Mascota actualizada exitosamente</response>
        /// <response code="400">Si la mascota no fue encontrada o hubo un error</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<MascotaResponseDTO>>> Update(int id,
            [FromBody] MascotaUpdateDTO mascotaUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mascotaService.UpdateAsync(id, mascotaUpdateDTO);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Elimina una mascota
        /// </summary>
        /// <param name="id">ID de la mascota a eliminar</param>
        /// <returns>Resultado de la eliminación</returns>
        /// <response code="200">Mascota eliminada exitosamente</response>
        /// <response code="400">Si la mascota no fue encontrada o hubo un error</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<bool>>> Delete(int id)
        {
            var result = await _mascotaService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

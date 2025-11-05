using Microsoft.AspNetCore.Mvc;
using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    /// <summary>
    /// Controlador para gestionar clientes de la veterinaria
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Obtiene todos los clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        /// <response code="200">Retorna la lista de clientes exitosamente</response>
        /// <response code="400">Si hubo un error al obtener los clientes</response>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<IEnumerable<ClienteResponseDTO>>>> GetAll()
        {
            var result = await _clienteService.GetAllAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene un cliente por su ID
        /// </summary>
        /// <param name="id">ID del cliente</param>
        /// <returns>Cliente encontrado</returns>
        /// <response code="200">Retorna el cliente exitosamente</response>
        /// <response code="400">Si el cliente no fue encontrado o hubo un error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<ClienteResponseDTO>>> GetById(int id)
        {
            var result = await _clienteService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Crea un nuevo cliente
        /// </summary>
        /// <param name="clienteCreateDTO">Datos del cliente a crear</param>
        /// <returns>Cliente creado</returns>
        /// <response code="201">Cliente creado exitosamente</response>
        /// <response code="400">Si hubo un error en la validación o creación</response>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<ClienteResponseDTO>>> Create(
            [FromBody] ClienteCreateDTO clienteCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _clienteService.CreateAsync(clienteCreateDTO);
            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Actualiza un cliente existente
        /// </summary>
        /// <param name="id">ID del cliente a actualizar</param>
        /// <param name="clienteUpdateDTO">Datos actualizados del cliente</param>
        /// <returns>Cliente actualizado</returns>
        /// <response code="200">Cliente actualizado exitosamente</response>
        /// <response code="400">Si el cliente no fue encontrado o hubo un error</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<ClienteResponseDTO>>> Update(int id,
            [FromBody] ClienteUpdateDTO clienteUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _clienteService.UpdateAsync(id, clienteUpdateDTO);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Elimina un cliente
        /// </summary>
        /// <param name="id">ID del cliente a eliminar</param>
        /// <returns>Resultado de la eliminación</returns>
        /// <response code="200">Cliente eliminado exitosamente</response>
        /// <response code="400">Si el cliente no fue encontrado o hubo un error</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<bool>>> Delete(int id)
        {
            var result = await _clienteService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Veterinaria.DTOs;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // TODO: Implementar endpoints
    }
}

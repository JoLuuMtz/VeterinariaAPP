using Microsoft.AspNetCore.Mvc;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialMedicoController : ControllerBase
    {
        private readonly IHistorialMedicoService _historialMedicoService;

        public HistorialMedicoController(IHistorialMedicoService historialMedicoService)
        {
            _historialMedicoService = historialMedicoService;
        }

        // TODO: Implementar endpoints
    }
}

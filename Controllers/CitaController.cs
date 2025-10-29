using Microsoft.AspNetCore.Mvc;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        // TODO: Implementar endpoints
    }
}

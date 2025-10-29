using Microsoft.AspNetCore.Mvc;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinarioController : ControllerBase
    {
        private readonly IVeterinarioService _veterinarioService;

        public VeterinarioController(IVeterinarioService veterinarioService)
        {
            _veterinarioService = veterinarioService;
        }

        // TODO: Implementar endpoints
    }
}

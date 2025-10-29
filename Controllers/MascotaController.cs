using Microsoft.AspNetCore.Mvc;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;

        public MascotaController(IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        // TODO: Implementar endpoints
    }
}

using Microsoft.AspNetCore.Mvc;
using Veterinaria.Interfaces;

namespace Veterinaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoService _medicamentoService;

        public MedicamentoController(IMedicamentoService medicamentoService)
        {
            _medicamentoService = medicamentoService;
        }

        // TODO: Implementar endpoints
    }
}

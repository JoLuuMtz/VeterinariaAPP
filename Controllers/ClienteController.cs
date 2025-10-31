using Microsoft.AspNetCore.Mvc;
using Veterinaria.DTOs;
using Veterinaria.Interfaces;
using Veterinaria.Models;
using VeterinariaApp.Models;

namespace Veterinaria.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("all")]
        public  ActionResult<IEnumerable<Cliente>> GetAll()
        {

            var clientes = new List<Cliente>
{
    new Cliente
    {
        Id = 1,
        Nombre = "Juan",
        Apellido = "Pérez",
        Telefono = "123-456-7890",
        Email = "juan.perez@gmail.com",
        DocumentoIdentidad = "A123456789",
        Direccion = "Calle Principal 123",
        FechaRegistro = DateTime.Now.AddYears(-2),
        Activo = true
    },
    new Cliente
    {
        Id = 2,
        Nombre = "María",
        Apellido = "González",
        Telefono = "098-765-4321",
        Email = "maria.gonzalez@gmail.com",
        DocumentoIdentidad = "B987654321",
        Direccion = "Avenida Central 456",
        FechaRegistro = DateTime.Now.AddMonths(-6),
        Activo = true
    },
    new Cliente
    {
        Id = 3,
        Nombre = "Carlos",
        Apellido = "Rodríguez",
        Telefono = "555-123-4567",
        Email = "carlos.rodriguez@hotmail.com",
        DocumentoIdentidad = "C456789123",
        Direccion = "Plaza Mayor 789",
        FechaRegistro = DateTime.Now.AddDays(-45),
        Activo = true
    },
    new Cliente
    {
        Id = 4,
        Nombre = "Ana",
        Apellido = "Martínez",
        Telefono = "777-888-9999",
        Email = "ana.martinez@yahoo.com",
        DocumentoIdentidad = "D789123456",
        Direccion = "Calle Secundaria 321",
        FechaRegistro = DateTime.Now.AddYears(-1),
        Activo = false
    },
    new Cliente
    {
        Id = 5,
        Nombre = "Luis",
        Apellido = "Sánchez",
        Telefono = "444-555-6666",
        Email = "luis.sanchez@outlook.com",
        DocumentoIdentidad = "E147258369",
        Direccion = "Avenida Norte 147",
        FechaRegistro = DateTime.Now.AddMonths(-3),
        Activo = true
    }
};
            return Ok(clientes);
        }
    }
}

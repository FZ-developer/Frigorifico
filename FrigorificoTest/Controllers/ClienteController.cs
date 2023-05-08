using Common.DTO.ClienteDTOs;
using Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrigorificoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpPost("AgregarCliente")]
        public async Task<IActionResult> AddClienteAsync([FromBody] ClienteDTO clienteDTO)
        {
            var response = await _clienteService.AddClienteAsync(clienteDTO);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("ObtenerTodosLosClientes")]
        public async Task<IActionResult> GetAllClientesAsync()
        {
            var response = await _clienteService.GetAllClientesAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("ObtenerClientePorId")]
        public async Task<IActionResult> GetClienteByIdAsync(int id)
        {
            var response = await _clienteService.GetClienteByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("ObtenerSaldosACobrar")]
        public async Task<IActionResult> GetAllSaldosACobrarAsync()
        {
            var response = await _clienteService.GetAllSaldosACobrarAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("ObtenerSaldosPorIdCliente")]
        public async Task<IActionResult> GetSaldoACobrarByClienteIdAsync(int id)
        {
            var response = await _clienteService.GetSaldoACobrarByClienteIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}

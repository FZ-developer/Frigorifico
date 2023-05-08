using Common.DTO.FacturaVentaDTOs;
using Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrigorificoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaVentaController : ControllerBase
    {
        private readonly IFacturaVentaService _facturaVentaService;

        public FacturaVentaController(IFacturaVentaService facturaVentaService)
        {
            _facturaVentaService = facturaVentaService;
        }

        [HttpPost("AgregarFacturaVenta")]
        public async Task<IActionResult> AddFacturaVenta([FromBody] FacturaVentaDTO facturaVentaDTO)
        {
            if (facturaVentaDTO == null || facturaVentaDTO.DetallesFactura == null || !facturaVentaDTO.DetallesFactura.Any())
            {
                return BadRequest();
            }

            var response = await _facturaVentaService.AddFacturaVentaAsync(facturaVentaDTO);

            return StatusCode(response.StatusCode, response);
        }








    }
}

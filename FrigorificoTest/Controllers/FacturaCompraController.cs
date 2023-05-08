using Common.DTO.FacturaCompraDTOs;
using Common.DTO.ProductoDTOs;
using Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrigorificoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaCompraController : ControllerBase
    {
        private readonly IFacturaCompraService _facturaCompraService;

        public FacturaCompraController(IFacturaCompraService facturaCompraService)
        {
            _facturaCompraService = facturaCompraService;
        }

        
        [HttpPost("AgregarFacturaCompra")]
        public async Task<IActionResult> AddFacturaCompraAsync([FromBody] FacturaCompraDTO facturaCompraDTO)
        {
            var response = await _facturaCompraService.AddFacturaCompraAsync(facturaCompraDTO);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpGet("ObtenerTodasLasFacturasCompra")]
        public async Task<IActionResult> GetAllFacturasCompraAsync()
        {
            var response = await _facturaCompraService.GetAllFacturasCompraAsync();
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpGet("ObtenerFacturasCompraPorIdCampo")]
        public async Task<IActionResult> GetFacturasCompraByCampoIdAsync([FromQuery] int idCampo)
        {
            var response = await _facturaCompraService.GetFacturasCompraByCampoIdAsync(idCampo);
            return StatusCode(response.StatusCode, response);
        }
        

    }
}

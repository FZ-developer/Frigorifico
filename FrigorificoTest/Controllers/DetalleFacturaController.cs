using Common.DTO.DetalleFacturaDTOs;
using Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrigorificoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController : ControllerBase
    {
        private readonly IDetalleFacturaService _detalleFacturaService;

        public DetalleFacturaController(IDetalleFacturaService detalleFacturaService)
        {
            _detalleFacturaService = detalleFacturaService;
        }


        [HttpPost("FacturaVenta/{idFacturaVenta}/detalles")]
        public async Task<IActionResult> AddDetallesFactura(int idFacturaVenta, [FromBody] IEnumerable<DetalleFacturaDTO> detallesFacturaDTO)
        {
            if (detallesFacturaDTO == null || detallesFacturaDTO.Count() == 0)
            {
                return BadRequest();
            }

            var response = await _detalleFacturaService.AddDetallesFacturaAsync(idFacturaVenta, detallesFacturaDTO);

            return StatusCode(response.StatusCode, response);
        }




    }
}

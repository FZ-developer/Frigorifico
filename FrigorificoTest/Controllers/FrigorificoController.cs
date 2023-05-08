using Common.DTO.Frigorifico;
using Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Swashbuckle.AspNetCore.Annotations;

namespace FrigorificoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrigorificoController : ControllerBase
    {
        private readonly IFrigorificoService _frigorificoService;

        public FrigorificoController(IFrigorificoService frigorificoService)
        {
            _frigorificoService = frigorificoService;
        }


        [HttpPost("AgregarFrigorifico")]        
        public async Task<IActionResult> AddFrigorificoAsync([FromBody] FrigorificoDTO frigorificoDTO)
        {
            var response = await _frigorificoService.AddFrigorificoAsync(frigorificoDTO);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("ObtenerFrigorificoPorId")]
        public async Task<IActionResult> GetCampoByIdAsync(int id)
        {
            var response = await _frigorificoService.GetFrigorificoByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}

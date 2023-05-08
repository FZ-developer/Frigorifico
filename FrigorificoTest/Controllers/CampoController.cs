using Common.DTO.CampoDTOs;
using Common.DTO.Frigorifico;
using Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FrigorificoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampoController : ControllerBase
    {
        private readonly ICampoService _campoService;

        public CampoController(ICampoService campoService)
        {
            _campoService = campoService;
        }


        [HttpPost("AgregarCampo")]
        public async Task<IActionResult> AddCampoAsync([FromBody] CampoDTO campoDTO)
        {
            var response = await _campoService.AddCampoAsync(campoDTO);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("ObtenerTodosLosCampos")]
        public async Task<IActionResult> GetAllCamposAsync()
        {
            var response = await _campoService.GetAllCamposAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("ObtenerCampoPorId")]
        public async Task<IActionResult> GetCampoByIdAsync(int id)
        {
            var response = await _campoService.GetCampoByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}

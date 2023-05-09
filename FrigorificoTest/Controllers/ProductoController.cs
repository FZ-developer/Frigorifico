using Common.DTO.ClienteDTOs;
using Common.DTO.ProductoDTOs;
using Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrigorificoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }


        [HttpPost("AgregarProducto")]
        public async Task<IActionResult> AddProductoAsync([FromBody] ProductoDTO productoDTO)
        {
            var response = await _productoService.AddProductoAsync(productoDTO);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost("AgregarVariosProductos")]
        public async Task<IActionResult> AddProductosAsync([FromBody] IEnumerable<ProductoDTO> productoDTOs)
        {
            var response = await _productoService.AddProductosAsync(productoDTOs);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPut("ActualizarProducto/{id}")]
        public async Task<IActionResult> UpdateProductoAsync(int id, [FromBody] ProductoDTO productoDTO)
        {
            var response = await _productoService.UpdateStockProductoAsync(id, productoDTO);
            return StatusCode(response.StatusCode, response);
        }


        [HttpGet("ObtenerTodosLosProductos")]
        public async Task<IActionResult> GetAllProductosAsync()
        {
            var response = await _productoService.GetAllProductosAsync();
            return StatusCode(response.StatusCode, response);
        }


        [HttpGet("ObtenerProductoPorId")]
        public async Task<IActionResult> GetProductoByIdAsync(int id)
        {
            var response = await _productoService.GetProductoByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }





        [HttpPost("AgregarVacasAFaena/{cantidadVacas}")]
        public async Task<IActionResult> AddFaena(int cantidadVacas)
        {
            var response = await _productoService.AddFaena(cantidadVacas);
            return StatusCode(response.StatusCode, response);
        }
    }
}

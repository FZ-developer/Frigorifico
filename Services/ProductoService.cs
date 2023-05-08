using Common.DTO.ClienteDTOs;
using Common.DTO;
using Contracts.Repositories;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO.ProductoDTOs;
using Contracts.Services;

namespace Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }


        public async Task<ResponseDTO> AddProductoAsync(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                Nombre = productoDTO.Nombre,
                StockPorKg = productoDTO.StockPorKg,
                PrecioPorKg = productoDTO.PrecioPorKg
            };

            await _productoRepository.AddProductoAsync(producto);
            await _productoRepository.SaveChangesAsync();

            var response = new ResponseDTO
            {
                Success = true,
                Result = producto,
                Message = $"El producto {producto.Nombre} ha sido agregado correctamente.",
                StatusCode = 201
            };

            return response;
        }

        public async Task<ResponseDTO> AddProductosAsync(IEnumerable<ProductoDTO> productoDTOs)
        {           
            var productos = new List<Producto>();
            foreach (var dto in productoDTOs)
            {
                var producto = new Producto
                {
                    IdFrigorifico = dto.IdFrigorifico,
                    Nombre = dto.Nombre,
                    StockPorKg = dto.StockPorKg,
                    PrecioPorKg = dto.PrecioPorKg
                };
                productos.Add(producto);
            }

            var response = new ResponseDTO();
            try
            {
                await _productoRepository.AddProductosAsync(productos);
                await _productoRepository.SaveChangesAsync();
                response.Success = true;
                response.Message = "Los productos se han agregado correctamente";
                response.StatusCode = 201;                
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.StatusCode = 500;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseDTO> GetAllProductosAsync()
        {
            var productos = await _productoRepository.GetAllProductosAsync();

            if (productos == null || !productos.Any())
            {
                var responseNoData = new ResponseDTO
                {
                    Success = false,
                    Message = "Por el momento no hay ningún producto cargado.",
                    StatusCode = 404
                };

                return responseNoData;
            }

            var responseWithData = new ResponseDTO
            {
                Success = true,
                Result = productos,
                Message = "Productos obtenidos correctamente.",
                StatusCode = 200
            };

            return responseWithData;
        }

        public async Task<ResponseDTO> GetProductoByIdAsync(int id)
        {
            var producto = await _productoRepository.GetProductoByIdAsync(id);

            if (producto == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Result = null,
                    Message = "No existe ningún producto con ese id.",
                    StatusCode = 404
                };
            }

            var response = new ResponseDTO
            {
                Success = true,
                Result = producto,
                Message = "Producto obtenido correctamente.",
                StatusCode = 200
            };

            return response;
        }
    }
}

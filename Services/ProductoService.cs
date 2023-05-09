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
using Repositories;

namespace Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IFrigorificoRepository _frigorificoRepository;

        public ProductoService(IProductoRepository productoRepository, IFrigorificoRepository frigorificoRepository)
        {
            _productoRepository = productoRepository;
            _frigorificoRepository = frigorificoRepository;
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

        public async Task<ResponseDTO> UpdateStockProductoAsync(int id, ProductoDTO productoDTO)
        {
            var producto = await _productoRepository.GetProductoByIdAsync(id);

            if (producto == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"El producto con ID {id} no existe.",
                    StatusCode = 404
                };
            }

            producto.StockPorKg = productoDTO.StockPorKg;

            await _productoRepository.UpdateStockProductoAsync(producto);
            await _productoRepository.SaveChangesAsync();

            return new ResponseDTO
            {
                Success = true,
                Result = producto,
                Message = $"El producto {producto.Nombre} ha sido actualizado correctamente.",
                StatusCode = 200
            };
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











        public async Task<ResponseDTO> AddFaena(int cantidadVacas)
        {
            var frigorifico = await _frigorificoRepository.GetFrigorificoByIdAsync(1);

            if (frigorifico.CantidadVacas < cantidadVacas)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "No hay suficientes vacas en el frigorífico.",
                    StatusCode = 400
                };
            }

            frigorifico.CantidadVacas -= cantidadVacas;

            var productos = await _productoRepository.GetAllProductosAsync();

            foreach (var producto in productos)
            {
                producto.StockPorKg += cantidadVacas * GetStockPorKgByProducto(producto.Nombre);
                await _productoRepository.UpdateStockProductoAsync(producto);
            }

            await _frigorificoRepository.SaveChangesAsync();
            await _productoRepository.SaveChangesAsync();

            return new ResponseDTO
            {
                Success = true,
                Message = "La faena ha sido realizada con éxito.",
                StatusCode = 200
            };
        }














        private int GetStockPorKgByProducto(string productoNombre)
        {
            switch (productoNombre.ToLower())
            {
                case "lomo":
                    return 4;
                case "asado":
                    return 16;
                case "bife ancho":
                    return 10;
                case "bife angosto":
                    return 6;
                case "bola de lomo":
                    return 2;
                case "colita de cuadril":
                    return 2;
                case "matambre":
                    return 1;
                case "peceto":
                    return 3;
                case "picanha":
                    return 1;
                default:
                    return 0;
            }
        }
    }
}

using Common.DTO.ProductoDTOs;
using Common.DTO;
using Contracts.Repositories;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IProductoService
    {
        Task<ResponseDTO> AddProductoAsync(ProductoDTO productoDTO);
        Task<ResponseDTO> AddProductosAsync(IEnumerable<ProductoDTO> productoDTOs);
        Task<ResponseDTO> GetAllProductosAsync();
        Task<ResponseDTO> GetProductoByIdAsync(int id);
    }
}

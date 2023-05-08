using Common.DTO.FacturaCompraDTOs;
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
    public interface IFacturaCompraService
    {
        Task<ResponseDTO> AddFacturaCompraAsync(FacturaCompraDTO facturaCompraDTO);
        Task<ResponseDTO> GetAllFacturasCompraAsync();
        Task<ResponseDTO> GetFacturasCompraByCampoIdAsync(int idCampo);
    }
}

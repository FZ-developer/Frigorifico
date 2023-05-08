using Common.DTO.FacturaVentaDTOs;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IFacturaVentaService
    {
        Task<ResponseDTO> AddFacturaVentaAsync(FacturaVentaDTO facturaVentaDTO);
    }
}

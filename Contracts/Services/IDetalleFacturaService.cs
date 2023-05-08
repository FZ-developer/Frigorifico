using Common.DTO.DetalleFacturaDTOs;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IDetalleFacturaService
    {
        Task<ResponseDTO> AddDetallesFacturaAsync(int idFacturaVenta, IEnumerable<DetalleFacturaDTO> detallesFacturaDTO);
    }
}

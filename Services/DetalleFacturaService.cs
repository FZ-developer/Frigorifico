using Common.DTO.DetalleFacturaDTOs;
using Common.DTO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Contracts.Repositories;
using Contracts.Services;

namespace Services
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private readonly IDetalleFacturaRepository _detalleFacturaRepository;

        public DetalleFacturaService(IDetalleFacturaRepository detalleFacturaRepository)
        {
            _detalleFacturaRepository = detalleFacturaRepository;
        }



        public async Task<ResponseDTO> AddDetallesFacturaAsync(int idFacturaVenta, IEnumerable<DetalleFacturaDTO> detallesFacturaDTO)
        {
            var detallesFactura = new List<DetalleFactura>();
            foreach (var detalleFacturaDTO in detallesFacturaDTO)
            {
                var detalleFactura = new DetalleFactura
                {
                    IdProducto = detalleFacturaDTO.IdProducto,
                    CantidadPorKg = detalleFacturaDTO.CantidadPorKg,
                    PrecioTotalProducto = detalleFacturaDTO.PrecioTotalProducto
                };
                detallesFactura.Add(detalleFactura);
            }

            var response = new ResponseDTO();
            try
            {
                await _detalleFacturaRepository.AddDetallesFacturaAsync(detallesFactura, idFacturaVenta);
                response.Success = true;
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


    }
}

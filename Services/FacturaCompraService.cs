using Common.DTO.ProductoDTOs;
using Common.DTO;
using Contracts.Repositories;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.DTO.FacturaCompraDTOs.FacturaCompraDTO;
using System.Text.Json.Serialization;
using Common.DTO.FacturaCompraDTOs;
using Contracts.Services;
using Repositories;
using Common.DTO.FacturaVentaDTOs;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace Services
{
    public class FacturaCompraService : IFacturaCompraService
    {
        private readonly FrigorificoContext _context;
        private readonly IFacturaCompraRepository _facturaCompraRepository;
        private readonly ICampoRepository _campoRepository;
        private readonly IFrigorificoRepository _frigorificoRepository;

        public FacturaCompraService(IFacturaCompraRepository facturaCompraRepository, ICampoRepository campoRepository, IFrigorificoRepository frigorificoRepository, FrigorificoContext context)
        {
            _facturaCompraRepository = facturaCompraRepository;
            _campoRepository = campoRepository;
            _frigorificoRepository = frigorificoRepository;
            _context = context;
        }


        public async Task<ResponseDTO> AddFacturaCompraAsync(FacturaCompraDTO facturaCompraDTO)
        {
            try
            {
                var campo = await _context.Campos.FirstOrDefaultAsync(c => c.Id == facturaCompraDTO.IdCampo);
                var frigorifico = await _context.Frigorificos.FirstOrDefaultAsync(f => f.Id == facturaCompraDTO.IdFrigorifico);

                if (campo == null || frigorifico == null)
                {
                    return new ResponseDTO
                    {
                        Message = "No se encontró el campo o el frigorífico",
                        Success = false
                    };
                }

                var facturaCompra = new FacturaCompra
                {
                    FechaCompra = facturaCompraDTO.FechaCompra,
                    IdCampo = facturaCompraDTO.IdCampo,
                    IdFrigorifico = facturaCompraDTO.IdFrigorifico,
                    TipoDePago = (TipoDePago)facturaCompraDTO.TipoDePago,
                    CantidadVacas = facturaCompraDTO.CantidadVacas,
                    PrecioVaca = facturaCompraDTO.PrecioVaca,
                    PrecioTotalCompra = facturaCompraDTO.CantidadVacas * facturaCompraDTO.PrecioVaca
                };

                frigorifico.CantidadVacas += facturaCompraDTO.CantidadVacas;
                campo.CantidadVacas -= facturaCompraDTO.CantidadVacas;

                if (facturaCompra.TipoDePago == TipoDePago.Contado)
                {
                    frigorifico.Caja -= facturaCompra.PrecioTotalCompra;
                }
                else if (facturaCompra.TipoDePago == TipoDePago.CuentaCorriente)
                {
                    campo.DeudaAPagar += facturaCompra.PrecioTotalCompra;
                }

                _context.FacturasCompra.Add(facturaCompra);
                await _context.SaveChangesAsync();

                return new ResponseDTO
                {
                    Message = "Factura de compra agregada correctamente",
                    Result = facturaCompra,
                    Success = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    Message = "Error al agregar la factura de compra: " + ex.Message,
                    Success = false,
                    StatusCode = 400
                };
            }
        }


        public async Task<ResponseDTO> GetAllFacturasCompraAsync()
        {
            var facturas = await _facturaCompraRepository.GetAllFacturasCompraAsync();

            if (facturas == null || !facturas.Any())
            {
                var responseNoData = new ResponseDTO
                {
                    Success = false,
                    Message = "Por el momento no hay ninguna factura de compra cargada.",
                    StatusCode = 404
                };

                return responseNoData;
            }

            var responseWithData = new ResponseDTO
            {
                Success = true,
                Result = facturas,
                Message = "Facturas de compra obtenidas correctamente.",
                StatusCode = 200
            };

            return responseWithData;
        }

        public async Task<ResponseDTO> GetFacturasCompraByCampoIdAsync(int idCampo)
        {
            var facturas = await _facturaCompraRepository.GetAllFacturasCompraAsync();

            var facturasFiltradas = facturas.Where(f => f.IdCampo == idCampo);

            if (!facturasFiltradas.Any())
            {
                var responseNoData = new ResponseDTO
                {
                    Success = false,
                    Message = "No se encontraron facturas de compra para el campo especificado.",
                    StatusCode = 404
                };

                return responseNoData;
            }

            var responseWithData = new ResponseDTO
            {
                Success = true,
                Result = facturasFiltradas,
                Message = $"Facturas de compra del campo con id {idCampo} obtenidas correctamente.",
                StatusCode = 200
            };

            return responseWithData;
        }

    }
}

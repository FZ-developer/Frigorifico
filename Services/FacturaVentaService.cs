using Common.DTO.ProductoDTOs;
using Common.DTO;
using Contracts.Repositories;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO.FacturaVentaDTOs;
using Repositories;
using Contracts.Services;

namespace Services
{
    public class FacturaVentaService : IFacturaVentaService
    {
        private readonly IFacturaVentaRepository _facturaVentaRepository;
        private readonly IFrigorificoRepository _frigorificoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProductoRepository _productoRepository;

        public FacturaVentaService(IFacturaVentaRepository facturaVentaRepository, IFrigorificoRepository frigorificoRepository, 
            IClienteRepository clienteRepository, IProductoRepository productoRepository)
        {
            _facturaVentaRepository = facturaVentaRepository;
            _frigorificoRepository = frigorificoRepository;
            _clienteRepository = clienteRepository;
            _productoRepository = productoRepository;
        }


        public async Task<ResponseDTO> AddFacturaVentaAsync(FacturaVentaDTO facturaVentaDTO)
        {
            var frigorifico = await _frigorificoRepository.GetFrigorificoByIdAsync(facturaVentaDTO.IdFrigorifico);
            var cliente = await _clienteRepository.GetClienteByIdAsync(facturaVentaDTO.IdCliente);

            var facturaVenta = new FacturaVenta
            {
                FechaVenta = facturaVentaDTO.FechaVenta,
                IdFrigorifico = facturaVentaDTO.IdFrigorifico,
                TipoDePago = (TipoDePago)facturaVentaDTO.TipoDePago,
                Vendedor = facturaVentaDTO.Vendedor,
                IdCliente = facturaVentaDTO.IdCliente
            };

            foreach (var detalleFacturaDTO in facturaVentaDTO.DetallesFactura)
            {
                var producto = await _productoRepository.GetProductoByIdAsync(detalleFacturaDTO.IdProducto);

                var detalleFactura = new DetalleFactura
                {
                    IdProducto = detalleFacturaDTO.IdProducto,
                    CantidadPorKg = detalleFacturaDTO.CantidadPorKg,                    
                    PrecioTotalProducto = detalleFacturaDTO.CantidadPorKg * producto.PrecioPorKg
                };

                facturaVenta.DetallesFactura.Add(detalleFactura);

                producto.StockPorKg -= detalleFacturaDTO.CantidadPorKg;
            }

            facturaVenta.PrecioTotalVenta = facturaVenta.DetallesFactura.Sum(df => df.PrecioTotalProducto);

            await _facturaVentaRepository.AddFacturaVentaAsync(facturaVenta);
            await _facturaVentaRepository.SaveChangesAsync();

            if (facturaVenta.TipoDePago == TipoDePago.Contado)
            {
                frigorifico.Caja += facturaVenta.PrecioTotalVenta;
            }
            else if (facturaVenta.TipoDePago == TipoDePago.CuentaCorriente)
            {
                frigorifico.DeudasACobrar += facturaVenta.PrecioTotalVenta;
                cliente.SaldoACobrar += facturaVenta.PrecioTotalVenta;
            }

            await _frigorificoRepository.SaveChangesAsync();
            await _clienteRepository.SaveChangesAsync();

            var response = new ResponseDTO
            {
                Success = true,
                Result = facturaVenta,
                Message = $"La factura de venta a nombre de {cliente.Nombre}, ha sido agregada correctamente.",
                StatusCode = 201
            };

            return response;
        }

    }
}

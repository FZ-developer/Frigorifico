using Common.DTO.CampoDTOs;
using Common.DTO;
using Contracts.Repositories;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO.ClienteDTOs;
using System.ComponentModel.DataAnnotations;
using Contracts.Services;

namespace Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        public async Task<ResponseDTO> AddClienteAsync(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente
            {                
                Nombre = clienteDTO.Nombre,
                Direccion = clienteDTO.Direccion,
                Ciudad = clienteDTO.Ciudad,
                Mail = clienteDTO.Mail,
                Telefono = clienteDTO.Telefono,
                SaldoACobrar = clienteDTO.SaldoACobrar
            };

            await _clienteRepository.AddClienteAsync(cliente);
            await _clienteRepository.SaveChangesAsync();

            var response = new ResponseDTO
            {
                Success = true,
                Result = cliente,
                Message = $"El cliente {cliente.Nombre} ha sido agregado correctamente.",
                StatusCode = 201
            };

            return response;
        }

        public async Task<ResponseDTO> GetAllClientesAsync()
        {
            var clientes = await _clienteRepository.GetAllClientesAsync();

            if (clientes == null || !clientes.Any())
            {
                var responseNoData = new ResponseDTO
                {
                    Success = false,
                    Message = "Por el momento no hay ningún cliente cargado.",
                    StatusCode = 404
                };

                return responseNoData;
            }

            var responseWithData = new ResponseDTO
            {
                Success = true,
                Result = clientes,
                Message = "Clientes obtenidos correctamente.",
                StatusCode = 200
            };

            return responseWithData;
        }

        public async Task<ResponseDTO> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);

            if (cliente == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Result = null,
                    Message = "No existe ningún cliente con ese id.",
                    StatusCode = 404
                };
            }

            var response = new ResponseDTO
            {
                Success = true,
                Result = cliente,
                Message = "Cliente obtenido correctamente.",
                StatusCode = 200
            };

            return response;
        }

        public async Task<ResponseDTO> GetAllSaldosACobrarAsync()
        {
            var saldosACobrar = await _clienteRepository.GetAllSaldosACobrarAsync();

            if (saldosACobrar == null || !saldosACobrar.Any())
            {
                var responseNoData = new ResponseDTO
                {
                    Success = false,
                    Message = "Por el momento no hay saldos a cobrar.",
                    StatusCode = 404
                };

                return responseNoData;
            }

            var responseWithData = new ResponseDTO
            {
                Success = true,
                Result = saldosACobrar,
                Message = "Saldos a cobrar obtenidos correctamente.",
                StatusCode = 200
            };

            return responseWithData;
        }

        public async Task<ResponseDTO> GetSaldoACobrarByClienteIdAsync(int id)
        {

            var saldoACobrar = await _clienteRepository.GetSaldoACobrarByClienteIdAsync(id);

            if (saldoACobrar == 0)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Result = null,
                    Message = "No existe ningún cliente con ese id o su saldo a cobrar es cero.",
                    StatusCode = 404
                };
            }

            var response = new ResponseDTO
            {
                Success = true,
                Result = saldoACobrar,
                Message = "El saldo a cobrar del cliente, se ha obtenido correctamente.",
                StatusCode = 200
            };

            return response;
        }











    }
}

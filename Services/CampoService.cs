using Common.DTO.Frigorifico;
using Common.DTO;
using Contracts.Repositories;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO.CampoDTOs;
using Contracts.Services;
using Repositories;

namespace Services
{
    public class CampoService : ICampoService
    {

        private readonly ICampoRepository _campoRepository;

        public CampoService(ICampoRepository campoRepository)
        {
            _campoRepository = campoRepository;
        }


        public async Task<ResponseDTO> AddCampoAsync(CampoDTO campoDTO)
        {
            var campo = new Campo
            {
                Nombre = campoDTO.Nombre,
                Direccion = campoDTO.Direccion,
                Ciudad = campoDTO.Ciudad,
                Mail = campoDTO.Mail,
                Telefono = campoDTO.Telefono,
                CantidadVacas = campoDTO.CantidadVacas,
                DeudaAPagar = campoDTO.DeudaAPagar,
                IdFrigorifico = 1
            };

            await _campoRepository.AddCampoAsync(campo);
            await _campoRepository.SaveChangesAsync();

            var response = new ResponseDTO
            {
                Success = true,
                Result = campo,
                Message = $"El campo {campo.Nombre} ha sido agregado correctamente.",
                StatusCode = 201
            };

            return response;
        }

        public async Task<ResponseDTO> GetAllCamposAsync()
        {
            var campos = await _campoRepository.GetAllCamposAsync();

            if (campos == null || !campos.Any())
            {
                var responseNoData = new ResponseDTO
                {
                    Success = false,
                    Message = "Por el momento no hay ningún campo cargado.",
                    StatusCode = 404
                };

                return responseNoData;
            }

            var responseWithData = new ResponseDTO
            {
                Success = true,
                Result = campos,
                Message = "Campos obtenidos correctamente.",
                StatusCode = 200
            };

            return responseWithData;
        }

        public async Task<ResponseDTO> GetCampoByIdAsync(int id)
        {
            var campo = await _campoRepository.GetCampoByIdAsync(id);

            if (campo == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Result = null,
                    Message = "No existe ningún campo con ese id.",
                    StatusCode = 404
                };
            }

            var response = new ResponseDTO
            {
                Success = true,
                Result = campo,
                Message = "Campo obtenido correctamente.",
                StatusCode = 200
            };

            return response;
        }
    }

}



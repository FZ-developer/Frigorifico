using Common.DTO;
using Common.DTO.Frigorifico;
using Contracts.Repositories;
using Contracts.Services;
using DataAccess.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FrigorificoService : IFrigorificoService
    {

        private readonly IFrigorificoRepository _frigorificoRepository;

        public FrigorificoService(IFrigorificoRepository frigorificoRepository)
        {
            _frigorificoRepository = frigorificoRepository;
        }


        public async Task<ResponseDTO> AddFrigorificoAsync(FrigorificoDTO frigorificoDTO)
        {
            frigorificoDTO.CategoriaIVA = "Responsable Inscripto";

            var frigorifico = new Frigorifico
            {
                Nombre = frigorificoDTO.Nombre,
                RazonSocial = frigorificoDTO.RazonSocial,
                CUIT = frigorificoDTO.CUIT,
                CategoriaIVA = frigorificoDTO.CategoriaIVA,
                Direccion = frigorificoDTO.Direccion,
                Ciudad = frigorificoDTO.Ciudad,
                Telefono = frigorificoDTO.Telefono,
                Mail = frigorificoDTO.Mail,
                CantidadVacas = frigorificoDTO.CantidadVacas,
                Caja = frigorificoDTO.Caja,
                DeudasACobrar = frigorificoDTO.DeudasACobrar        
            };

            await _frigorificoRepository.AddFrigorificoAsync(frigorifico);
            await _frigorificoRepository.SaveChangesAsync();

            var response = new ResponseDTO
            {
                Success = true,
                Result = frigorifico,
                Message = $"El frigorífico {frigorifico.Nombre} ha sido agregado correctamente.",
                StatusCode = 201
            };

            return response;
        }


        public async Task<ResponseDTO> GetFrigorificoByIdAsync(int id)
        {
            var frigorifico = await _frigorificoRepository.GetFrigorificoByIdAsync(id);

            if (frigorifico == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Result = null,
                    Message = "No existe ningún frigorifico con ese id.",
                    StatusCode = 404
                };
            }

            var response = new ResponseDTO
            {
                Success = true,
                Result = frigorifico,
                Message = "Frigorifico obtenido correctamente.",
                StatusCode = 200
            };

            return response;
        }
    }
}

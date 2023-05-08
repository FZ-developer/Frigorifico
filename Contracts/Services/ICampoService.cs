using Common.DTO.CampoDTOs;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface ICampoService
    {
        Task<ResponseDTO> AddCampoAsync(CampoDTO campoDTO);
        Task<ResponseDTO> GetAllCamposAsync();
        Task<ResponseDTO> GetCampoByIdAsync(int id);
    }
}

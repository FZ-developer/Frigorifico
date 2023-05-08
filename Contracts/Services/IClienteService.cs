using Common.DTO.CampoDTOs;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO.ClienteDTOs;
using Contracts.Repositories;
using DataAccess.Models;

namespace Contracts.Services
{
    public interface IClienteService
    {
        Task<ResponseDTO> AddClienteAsync(ClienteDTO clienteDTO);
        Task<ResponseDTO> GetAllClientesAsync();
        Task<ResponseDTO> GetClienteByIdAsync(int id);
        Task<ResponseDTO> GetAllSaldosACobrarAsync();
        Task<ResponseDTO> GetSaldoACobrarByClienteIdAsync(int id);
    }
}

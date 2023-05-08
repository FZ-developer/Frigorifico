using Common.DTO.Frigorifico;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IFrigorificoService
    {
        Task<ResponseDTO> AddFrigorificoAsync(FrigorificoDTO frigorificoDTO);
        Task<ResponseDTO> GetFrigorificoByIdAsync(int id);
    }
}

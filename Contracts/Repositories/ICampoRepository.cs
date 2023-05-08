using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface ICampoRepository
    {
        Task AddCampoAsync(Campo campo);
        Task<IEnumerable<Campo>> GetAllCamposAsync();
        Task<Campo> GetCampoByIdAsync(int id);
        Task<int> SaveChangesAsync();
    }
}

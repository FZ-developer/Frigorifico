using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IFrigorificoRepository
    {
        Task AddFrigorificoAsync(Frigorifico frigorifico);
        Task<Frigorifico> GetFrigorificoByIdAsync(int id);
        Task<int> SaveChangesAsync();
    }
}

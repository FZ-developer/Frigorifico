using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IClienteRepository
    {
        Task AddClienteAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<List<decimal>> GetAllSaldosACobrarAsync();
        Task<decimal> GetSaldoACobrarByClienteIdAsync(int id);


        Task<int> SaveChangesAsync();
    }
}

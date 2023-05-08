using DataAccess.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly FrigorificoContext _context;

        public ClienteRepository(FrigorificoContext context)
        {
            _context = context;
        }


        public async Task AddClienteAsync(Cliente cliente)
        {
            await _context.Set<Cliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<List<decimal>> GetAllSaldosACobrarAsync()
        {
            return await _context.Clientes
                .Where(c => c.SaldoACobrar > 0)
                .Select(c => c.SaldoACobrar)
                .ToListAsync();
        }

        public async Task<decimal> GetSaldoACobrarByClienteIdAsync(int id)
        {
            var saldoACobrar = await _context.Clientes
                .Where(c => c.id == id && c.SaldoACobrar > 0)
                .Select(c => c.SaldoACobrar)
                .FirstOrDefaultAsync();

            return saldoACobrar;
        }














        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

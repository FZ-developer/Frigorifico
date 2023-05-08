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
    public class CampoRepository : ICampoRepository
    {
        private readonly FrigorificoContext _context;

        public CampoRepository(FrigorificoContext context)
        {
            _context = context;
        }


        public async Task AddCampoAsync(Campo campo)
        {
            await _context.Set<Campo>().AddAsync(campo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Campo>> GetAllCamposAsync()
        {
            return await _context.Campos.ToListAsync();
        }

        public async Task<Campo> GetCampoByIdAsync(int id)
        {
            return await _context.Campos.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

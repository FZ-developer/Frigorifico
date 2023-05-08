using Common.DTO.Frigorifico;
using Contracts.Repositories;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FrigorificoRepository : IFrigorificoRepository
    {
        private readonly FrigorificoContext _context;

        public FrigorificoRepository(FrigorificoContext context)
        {
            _context = context;
        }


        public async Task AddFrigorificoAsync(Frigorifico frigorifico)
        {
            await _context.Set<Frigorifico>().AddAsync(frigorifico);
            await _context.SaveChangesAsync();
        }

        public async Task<Frigorifico> GetFrigorificoByIdAsync(int id)
        {
            return await _context.Frigorificos.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }








    }
}

using DataAccess.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contracts.Repositories;

namespace Repositories
{
    public class FacturaCompraRepository : IFacturaCompraRepository
    {
        private readonly FrigorificoContext _context;

        public FacturaCompraRepository(FrigorificoContext context)
        {
            _context = context;
        }


        public async Task AddFacturaCompraAsync(FacturaCompra facturaCompra)
        {
            await _context.Set<FacturaCompra>().AddAsync(facturaCompra);
            await _context.SaveChangesAsync();
        }
                

        public async Task<IEnumerable<FacturaCompra>> GetAllFacturasCompraAsync()
        {
            return await _context.FacturasCompra.ToListAsync();
        }


        public async Task<IEnumerable<FacturaCompra>> GetFacturasCompraByCampoIdAsync(int idCampo)
        {
            var facturasCompra = await _context.FacturasCompra
                .Where(fc => fc.IdCampo == idCampo)
                .Include(fc => fc.Campo)
                .Include(fc => fc.Frigorifico)
                .ToListAsync();

            return facturasCompra;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

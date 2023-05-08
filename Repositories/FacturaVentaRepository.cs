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
    public class FacturaVentaRepository : IFacturaVentaRepository
    {
        private readonly FrigorificoContext _context;

        public FacturaVentaRepository(FrigorificoContext context)
        {
            _context = context;
        }


        public async Task AddFacturaVentaAsync(FacturaVenta facturaVenta)
        {
            await _context.Set<FacturaVenta>().AddAsync(facturaVenta);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FacturaVenta>> GetAllFacturasVentaAsync()
        {
            return await _context.FacturasVenta.ToListAsync();
        }

        public async Task<IEnumerable<FacturaVenta>> GetFacturasVentaByClienteIdAsync(int idCliente)
        {
            return await _context.FacturasVenta
                .Include(f => f.DetallesFactura)
                .ThenInclude(d => d.Producto)
                .Where(f => f.IdCliente == idCliente)
                .ToListAsync();
        }



        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

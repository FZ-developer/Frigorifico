using DataAccess.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repositories;

namespace Repositories
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private readonly FrigorificoContext _context;

        public DetalleFacturaRepository(FrigorificoContext context)
        {
            _context = context;
        }


        public async Task AddDetallesFacturaAsync(IEnumerable<DetalleFactura> detallesFactura, int idFacturaVenta)
        {
            foreach (var detalle in detallesFactura)
            {
                detalle.IdFacturaVenta = idFacturaVenta;
            }

            await _context.Set<DetalleFactura>().AddRangeAsync(detallesFactura);
            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

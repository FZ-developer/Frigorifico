using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IDetalleFacturaRepository
    {
        Task AddDetallesFacturaAsync(IEnumerable<DetalleFactura> detallesFactura, int idFacturaVenta);
        Task<int> SaveChangesAsync();
    }
}

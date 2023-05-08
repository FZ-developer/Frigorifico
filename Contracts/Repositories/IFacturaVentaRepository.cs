using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IFacturaVentaRepository
    {
        Task AddFacturaVentaAsync(FacturaVenta facturaVenta);
        Task<IEnumerable<FacturaVenta>> GetAllFacturasVentaAsync();
        Task<IEnumerable<FacturaVenta>> GetFacturasVentaByClienteIdAsync(int idCliente);
        Task<int> SaveChangesAsync();
    }
}

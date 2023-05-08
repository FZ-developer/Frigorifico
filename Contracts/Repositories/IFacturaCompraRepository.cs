using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IFacturaCompraRepository
    {
        Task AddFacturaCompraAsync(FacturaCompra facturaCompra);
        Task<IEnumerable<FacturaCompra>> GetAllFacturasCompraAsync();
        Task<IEnumerable<FacturaCompra>> GetFacturasCompraByCampoIdAsync(int idCampo);
        Task<int> SaveChangesAsync();
    }
}

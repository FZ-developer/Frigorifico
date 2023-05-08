using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IProductoRepository
    {
        Task AddProductoAsync(Producto producto);
        Task AddProductosAsync(IEnumerable<Producto> productos);
        Task<IEnumerable<Producto>> GetAllProductosAsync();
        Task<Producto> GetProductoByIdAsync(int id);



        Task<int> SaveChangesAsync();
    }
}

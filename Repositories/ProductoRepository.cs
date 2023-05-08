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
    public class ProductoRepository : IProductoRepository
    {
        private readonly FrigorificoContext _context;

        public ProductoRepository(FrigorificoContext context)
        {
            _context = context;
        }


        public async Task AddProductoAsync(Producto producto)
        {
            await _context.Set<Producto>().AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task AddProductosAsync(IEnumerable<Producto> productos)
        {
            await _context.Set<Producto>().AddRangeAsync(productos);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

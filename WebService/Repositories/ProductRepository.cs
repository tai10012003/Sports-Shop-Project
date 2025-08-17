using Microsoft.EntityFrameworkCore;
using WebService.Data;
using WebService.Interfaces.Products;
using WebService.Models;

namespace WebService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.HinhAnh)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.HinhAnh)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> GetByCodeAsync(string maSanPham)
        {
            return await _context.Products
                .Include(p => p.HinhAnh)
                .FirstOrDefaultAsync(p => p.MaSanPham == maSanPham);
        }

        public async Task<Product> GetBySlugAsync(string slug)
        {
            var product = await _context.Products.Include(p => p.HinhAnh).FirstOrDefaultAsync(p => p.Slug == slug);
            if (product != null)
            {
                product.LuotXem += 1;
                _context.Entry(product).Property(p => p.LuotXem).IsModified = true;
                await _context.SaveChangesAsync();
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetFeaturedAsync()
        {
            return await _context.Products
                .Include(p => p.HinhAnh)
                .Where(p => p.NoiBat)
                .OrderByDescending(p => p.NgayTao)
                .Take(4)
                .ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
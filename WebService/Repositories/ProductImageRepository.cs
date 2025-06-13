using Microsoft.EntityFrameworkCore;
using WebService.Data;
using WebService.Interfaces.ProductImages;
using WebService.Models;

namespace WebService.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly AppDbContext _context;

        public ProductImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            return await _context.ProductImages.ToListAsync();
        }

        public async Task<ProductImage?> GetByIdAsync(int id)
        {
            return await _context.ProductImages.FindAsync(id);
        }

        public async Task<IEnumerable<ProductImage>> GetByProductCodeAsync(string maSanPham)
        {
            return await _context.ProductImages
                .Where(i => i.MaSanPham == maSanPham)
                .OrderBy(i => i.ThuTu)
                .ToListAsync();
        }

        public async Task<ProductImage> CreateAsync(ProductImage productImage)
        {
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage;
        }

        public async Task UpdateAsync(ProductImage productImage)
        {
            _context.Entry(productImage).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var image = await _context.ProductImages.FindAsync(id);
            if (image != null)
            {
                _context.ProductImages.Remove(image);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetProductImageCountAsync(string maSanPham)
        {
            return await _context.ProductImages.CountAsync(i => i.MaSanPham == maSanPham);
        }

        public async Task UpdateMainImageFlagsAsync(string maSanPham, int mainImageId)
        {
            var images = await _context.ProductImages
                .Where(i => i.MaSanPham == maSanPham)
                .ToListAsync();

            foreach (var image in images)
            {
                image.AnhChinh = image.Id == mainImageId;
                image.NgayCapNhat = DateTime.Now;
            }

            await _context.SaveChangesAsync();
        }
    }
}
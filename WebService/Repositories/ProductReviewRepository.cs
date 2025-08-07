using Microsoft.EntityFrameworkCore;
using WebService.Data;
using WebService.Interfaces.ProductReviews;
using WebService.Models;

namespace WebService.Repositories
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly AppDbContext _context;

        public ProductReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductReview>> GetByProductAsync(string maSanPham)
        {
            return await _context.ProductReviews
                .Where(r => r.MaSanPham == maSanPham)
                .OrderByDescending(r => r.NgayTao)
                .ToListAsync();
        }

        public async Task<ProductReview?> GetByIdAsync(int id)
        {
            return await _context.ProductReviews.FindAsync(id);
        }

        public async Task<ProductReview> AddAsync(ProductReview review)
        {
            await _context.ProductReviews.AddAsync(review);
            return review;
        }

        public Task<ProductReview> UpdateAsync(ProductReview review)
        {
            _context.ProductReviews.Update(review);
            return Task.FromResult(review);
        }

        public Task<ProductReview> DeleteAsync(ProductReview review)
        {
            _context.ProductReviews.Remove(review);
            return Task.FromResult(review);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

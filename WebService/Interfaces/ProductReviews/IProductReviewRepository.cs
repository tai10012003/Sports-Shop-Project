using WebService.Models;

namespace WebService.Interfaces.ProductReviews
{
    public interface IProductReviewRepository
    {
        Task<IEnumerable<ProductReview>> GetByProductAsync(string maSanPham);
        Task<ProductReview?> GetByIdAsync(int id);
        Task<ProductReview> AddAsync(ProductReview review);
        Task<ProductReview> UpdateAsync(ProductReview review);
        Task<ProductReview> DeleteAsync(ProductReview review);
        Task SaveChangesAsync();
    }
}

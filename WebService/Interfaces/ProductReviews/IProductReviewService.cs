using WebService.DTOs.ProductReviews;
namespace WebService.Interfaces.ProductReviews
{
    public interface IProductReviewService
    {
        Task<IEnumerable<GetProductReviewDTO>> GetByProductAsync(string maSanPham);
        Task<GetProductReviewDTO> GetByIdAsync(int id);
        Task<ProductReviewResponseDTO> CreateAsync(CreateProductReviewDTO dto);
        Task<ProductReviewResponseDTO> UpdateAsync(int id, UpdateProductReviewDTO dto);
        Task<ProductReviewResponseDTO> DeleteAsync(int id);
    }
}

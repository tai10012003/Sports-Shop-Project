using WebService.Models;

namespace WebService.Interfaces.ProductImages
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<ProductImage>> GetAllAsync();
        Task<ProductImage?> GetByIdAsync(int id);
        Task<IEnumerable<ProductImage>> GetByProductCodeAsync(string maSanPham);
        Task<ProductImage> CreateAsync(ProductImage productImage);
        Task UpdateAsync(ProductImage productImage);
        Task DeleteAsync(int id);
        Task<int> GetProductImageCountAsync(string maSanPham);
        Task UpdateMainImageFlagsAsync(string maSanPham, int mainImageId);
    }
}
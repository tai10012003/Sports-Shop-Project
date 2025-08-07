using WebService.Models;

namespace WebService.Interfaces.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> GetBySlugAsync(string slug);
        Task<Product?> GetByCodeAsync(string maSanPham);
        Task<IEnumerable<Product>> GetFeaturedAsync();
        Task<Product> CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
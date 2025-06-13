using WebService.DTOs.Products;

namespace WebService.Interfaces.Products
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductDTO>> GetAllAsync();
        Task<ProductResponseDTO?> GetByIdAsync(int id);
        Task<ProductResponseDTO?> GetByCodeAsync(string maSanPham);
        Task<IEnumerable<GetProductDTO>> GetFeaturedAsync();
        Task<ProductResponseDTO> CreateAsync(CreateProductDTO productDto);
        Task UpdateAsync(int id, UpdateProductDTO productDto);
        Task DeleteAsync(int id);
    }
}
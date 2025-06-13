using Microsoft.AspNetCore.Http;
using WebService.DTOs.ProductImages;

namespace WebService.Interfaces.ProductImages
{
    public interface IProductImageService
    {
        Task<IEnumerable<ProductImageDTO>> GetAllAsync();
        Task<ProductImageDTO?> GetByIdAsync(int id);
        Task<IEnumerable<ProductImageDTO>> GetByProductCodeAsync(string maSanPham);
        Task<ProductImageDTO> CreateAsync(CreateProductImageDTO imageDto);
        Task UpdateAsync(int id, UpdateProductImageDTO imageDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductImageDTO>> GetByProductIdAsync(string maSanPham);
        Task<ProductImageDTO> UploadAsync(string maSanPham, IFormFile file);
        Task SetMainImageAsync(int id);
    }
}
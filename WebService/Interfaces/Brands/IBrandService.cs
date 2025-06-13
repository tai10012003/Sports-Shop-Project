using WebService.DTOs.Brands;

namespace WebService.Interfaces.Brands
{
    public interface IBrandService
    {
        Task<IEnumerable<GetBrandDTO>> GetAllAsync();
        Task<BrandResponseDTO?> GetByIdAsync(int id);
        Task<BrandResponseDTO?> GetByCodeAsync(string maThuongHieu);
        Task<BrandResponseDTO> CreateAsync(CreateBrandDTO brandDto);
        Task UpdateAsync(int id, UpdateBrandDTO brandDto);
        Task DeleteAsync(int id);
    }
}
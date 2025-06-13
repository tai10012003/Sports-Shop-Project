using WebService.Models;

namespace WebService.Interfaces.Brands
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllAsync();
        Task<Brand?> GetByIdAsync(int id);
        Task<Brand?> GetByCodeAsync(string maThuongHieu);
        Task<Brand> CreateAsync(Brand brand);
        Task UpdateAsync(Brand brand);
        Task DeleteAsync(int id);
    }
}
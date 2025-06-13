using WebService.DTOs.Categories;

namespace WebService.Interfaces.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDTO>> GetAllAsync();
        Task<CategoryResponseDTO?> GetByIdAsync(int id);
        Task<CategoryResponseDTO?> GetByCodeAsync(string maDanhMuc);
        Task<CategoryResponseDTO> CreateAsync(CreateCategoryDTO categoryDto);
        Task UpdateAsync(int id, UpdateCategoryDTO categoryDto);
        Task DeleteAsync(int id);
    }
}
using AutoMapper;
using WebService.DTOs.Categories;
using WebService.Interfaces.Categories;
using WebService.Models;

namespace WebService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCategoryDTO>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetCategoryDTO>>(categories);
        }

        public async Task<CategoryResponseDTO?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryResponseDTO>(category);
        }

        public async Task<CategoryResponseDTO?> GetByCodeAsync(string maDanhMuc)
        {
            var category = await _categoryRepository.GetByCodeAsync(maDanhMuc);
            return _mapper.Map<CategoryResponseDTO>(category);
        }

        public async Task<CategoryResponseDTO> CreateAsync(CreateCategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.NgayTao = DateTime.Now;
            category.NgayCapNhat = DateTime.Now;

            category = await _categoryRepository.CreateAsync(category);
            return _mapper.Map<CategoryResponseDTO>(category);
        }

        public async Task UpdateAsync(int id, UpdateCategoryDTO categoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {id} not found");

            _mapper.Map(categoryDto, category);
            category.NgayCapNhat = DateTime.Now;

            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WebService.DTOs.Categories;
using WebService.Interfaces.Categories;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDTO>>> GetCategories()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDTO>> GetCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponseDTO>> CreateCategory(CreateCategoryDTO categoryDto)
        {
            var result = await _categoryService.CreateAsync(categoryDto);
            return CreatedAtAction(nameof(GetCategory), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDTO categoryDto)
        {
            await _categoryService.UpdateAsync(id, categoryDto);
            return NoContent();
        }
    }
}
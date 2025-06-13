using Microsoft.AspNetCore.Mvc;
using WebService.DTOs.Brands;
using WebService.Interfaces.Brands;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBrandDTO>>> GetBrands()
        {
            return Ok(await _brandService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandResponseDTO>> GetBrand(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            if (brand == null)
                return NotFound();
            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<BrandResponseDTO>> CreateBrand(CreateBrandDTO brandDto)
        {
            var result = await _brandService.CreateAsync(brandDto);
            return CreatedAtAction(nameof(GetBrand), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, UpdateBrandDTO brandDto)
        {
            await _brandService.UpdateAsync(id, brandDto);
            return NoContent();
        }
    }
}
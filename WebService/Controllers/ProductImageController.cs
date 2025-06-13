using Microsoft.AspNetCore.Mvc;
using WebService.DTOs.ProductImages;
using WebService.Interfaces.ProductImages;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _imageService;

        public ProductImageController(IProductImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("{maSanPham}")]
        public async Task<ActionResult<IEnumerable<ProductImageDTO>>> GetProductImages(string maSanPham)
        {
            return Ok(await _imageService.GetByProductIdAsync(maSanPham));
        }

        [HttpPost("upload")]
        public async Task<ActionResult<ProductImageDTO>> UploadProductImage([FromForm] string maSanPham, IFormFile file)
        {
            try
            {
                var result = await _imageService.UploadAsync(maSanPham, file);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("set-main/{id}")]
        public async Task<IActionResult> SetMainImage(int id)
        {
            await _imageService.SetMainImageAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            await _imageService.DeleteAsync(id);
            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WebService.DTOs.Products;
using WebService.Interfaces.Products;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductDTO>>> GetProducts()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet("featured")]
        public async Task<ActionResult<IEnumerable<GetProductDTO>>> GetFeaturedProducts()
        {
            var products = await _productService.GetFeaturedAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDTO>> CreateProduct(CreateProductDTO product)
        {
            var createdProduct = await _productService.CreateAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDTO product)
        {
            await _productService.UpdateAsync(id, product);
            return NoContent();
        }
    }
}
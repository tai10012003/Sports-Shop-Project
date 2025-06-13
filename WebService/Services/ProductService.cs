using AutoMapper;
using WebService.DTOs.Products;
using WebService.Interfaces.Products;
using WebService.Models;

namespace WebService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductDTO>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetProductDTO>>(products);
        }

        public async Task<ProductResponseDTO?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<ProductResponseDTO?> GetByCodeAsync(string maSanPham)
        {
            var product = await _repository.GetByCodeAsync(maSanPham);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<IEnumerable<GetProductDTO>> GetFeaturedAsync()
        {
            var products = await _repository.GetFeaturedAsync();
            return _mapper.Map<IEnumerable<GetProductDTO>>(products);
        }

        public async Task<ProductResponseDTO> CreateAsync(CreateProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.NgayTao = DateTime.Now;
            product.NgayCapNhat = DateTime.Now;
            
            var createdProduct = await _repository.CreateAsync(product);
            return _mapper.Map<ProductResponseDTO>(createdProduct);
        }

        public async Task UpdateAsync(int id, UpdateProductDTO productDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found");

            _mapper.Map(productDto, product);
            product.NgayCapNhat = DateTime.Now;
            
            await _repository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
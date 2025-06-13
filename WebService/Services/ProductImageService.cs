using AutoMapper;
using Microsoft.AspNetCore.Http;
using WebService.DTOs.ProductImages;
using WebService.Interfaces.ProductImages;
using WebService.Models;

namespace WebService.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _repository;
        private readonly IMapper _mapper;
        private readonly string _uploadsPath;

        public ProductImageService(IProductImageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "vue", "src", "assets", "uploads", "products");
        }

        public async Task<IEnumerable<ProductImageDTO>> GetAllAsync()
        {
            var images = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductImageDTO>>(images);
        }

        public async Task<ProductImageDTO?> GetByIdAsync(int id)
        {
            var image = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductImageDTO>(image);
        }

        public async Task<IEnumerable<ProductImageDTO>> GetByProductCodeAsync(string maSanPham)
        {
            var images = await _repository.GetByProductCodeAsync(maSanPham);
            return _mapper.Map<IEnumerable<ProductImageDTO>>(images);
        }

        public async Task<IEnumerable<ProductImageDTO>> GetByProductIdAsync(string maSanPham)
        {
            var images = await _repository.GetByProductCodeAsync(maSanPham);
            return _mapper.Map<IEnumerable<ProductImageDTO>>(images);
        }

        public async Task<ProductImageDTO> CreateAsync(CreateProductImageDTO imageDto)
        {
            var image = _mapper.Map<ProductImage>(imageDto);
            image.NgayTao = DateTime.Now;
            image.NgayCapNhat = DateTime.Now;

            image = await _repository.CreateAsync(image);
            return _mapper.Map<ProductImageDTO>(image);
        }

        public async Task<ProductImageDTO> UploadAsync(string maSanPham, IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("No file was uploaded");

            if (!Directory.Exists(_uploadsPath))
                Directory.CreateDirectory(_uploadsPath);

            var fileName = $"{DateTime.Now:yyyyMMdd}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(_uploadsPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var productImage = new ProductImage
            {
                MaSanPham = maSanPham,
                DuongDan = $"/assets/uploads/products/{fileName}",
                ThuTu = await _repository.GetProductImageCountAsync(maSanPham),
                AnhChinh = false,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now
            };

            productImage = await _repository.CreateAsync(productImage);
            return _mapper.Map<ProductImageDTO>(productImage);
        }

        public async Task UpdateAsync(int id, UpdateProductImageDTO imageDto)
        {
            var image = await _repository.GetByIdAsync(id);
            if (image == null)
                throw new KeyNotFoundException($"ProductImage with ID {id} not found");

            _mapper.Map(imageDto, image);
            image.NgayCapNhat = DateTime.Now;

            await _repository.UpdateAsync(image);
        }

        public async Task SetMainImageAsync(int id)
        {
            var image = await _repository.GetByIdAsync(id);
            if (image == null)
                throw new KeyNotFoundException($"Image with ID {id} not found");

            await _repository.UpdateMainImageFlagsAsync(image.MaSanPham, id);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
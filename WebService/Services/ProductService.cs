using AutoMapper;
using WebService.DTOs.Products;
using WebService.Interfaces.Products;
using WebService.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<(IEnumerable<GetProductDTO> products, int totalCount)> GetAllAsync(
            string search = "",
            string category = "",
            string brand = "",
            string price = "",
            string sort = "",
            int page = 1,
            int pageSize = 9,
            bool promotion = false
        )
        {
            var products = await _repository.GetAllAsync();
            var query = products.AsQueryable();

            // Tìm kiếm không phân biệt hoa thường
            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();
                query = query.Where(p =>
                    (!string.IsNullOrEmpty(p.TenSanPham) && p.TenSanPham.ToLower().Contains(lowerSearch)) ||
                    (!string.IsNullOrEmpty(p.MaSanPham) && p.MaSanPham.ToLower().Contains(lowerSearch))
                );
            }

            // Lọc danh mục
            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.MaDanhMuc == category);

            // Lọc thương hiệu
            if (!string.IsNullOrEmpty(brand))
                query = query.Where(p => p.MaThuongHieu == brand);

            // Lọc giá
            if (!string.IsNullOrEmpty(price))
            {
                var range = price.Split('-');
                if (range.Length == 2)
                {
                    if (decimal.TryParse(range[0], out decimal min) && decimal.TryParse(range[1], out decimal max))
                        query = query.Where(p => p.Gia >= min && p.Gia <= max);
                    else if (range[1] == "up" && decimal.TryParse(range[0], out decimal minUp))
                        query = query.Where(p => p.Gia >= minUp);
                }
            }

            // Lọc khuyến mãi
            if (promotion)
                query = query.Where(p => p.GiaKhuyenMai != null && p.GiaKhuyenMai < p.Gia);

            // Sắp xếp
            query = ApplySorting(query, sort);

            // Tổng số sản phẩm trước khi phân trang
            int totalCount = query.Count();

            // Phân trang
            var pagedProducts = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (_mapper.Map<IEnumerable<GetProductDTO>>(pagedProducts), totalCount);
        }

        private IQueryable<Product> ApplySorting(IQueryable<Product> query, string sort)
        {
            switch (sort?.ToLower())
            {
                case "price_asc":
                    return query.OrderBy(p => p.GiaKhuyenMai ?? p.Gia);
                case "price_desc":
                    return query.OrderByDescending(p => p.GiaKhuyenMai ?? p.Gia);
                default:
                    return query.OrderBy(p => p.Id);
            }
        }

        public async Task<List<GetProductDTO>> GetSuggestionsAsync(string query)
{
    if (string.IsNullOrWhiteSpace(query)) return new List<GetProductDTO>();
    var products = await _repository.GetAllAsync();
    var lowerQuery = query.ToLower();
    return products
        .Where(p => !string.IsNullOrEmpty(p.TenSanPham) && p.TenSanPham.ToLower().Contains(lowerQuery))
        .Take(10)
        .Select(p => new GetProductDTO
        {
            Id = p.Id,
            TenSanPham = p.TenSanPham,
            Gia = p.Gia,
            GiaKhuyenMai = p.GiaKhuyenMai,
            HinhAnh = p.HinhAnh?
                .Select(img => new ProductImageInProductDTO
                {
                    Id = img.Id,
                    DuongDan = img.DuongDan,
                    AnhChinh = img.AnhChinh
                }).ToList() ?? new List<ProductImageInProductDTO>()
        })
        .ToList();
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
using AutoMapper;
using WebService.DTOs.ProductReviews;
using WebService.Interfaces.ProductReviews;
using WebService.Models;

namespace WebService.Services
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IProductReviewRepository _repo;
        private readonly IMapper _mapper;

        public ProductReviewService(IProductReviewRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductReviewDTO>> GetByProductAsync(string maSanPham)
        {
            var list = await _repo.GetByProductAsync(maSanPham);
            return _mapper.Map<IEnumerable<GetProductReviewDTO>>(list);
        }

        public async Task<GetProductReviewDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Không tìm thấy đánh giá");
            return _mapper.Map<GetProductReviewDTO>(entity);
        }

        public async Task<ProductReviewResponseDTO> CreateAsync(CreateProductReviewDTO dto)
        {
            var entity = _mapper.Map<ProductReview>(dto);
            entity.NgayTao = entity.NgayCapNhat = DateTime.Now;

            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();

            var result = _mapper.Map<ProductReviewResponseDTO>(entity);
            result.Message = "Tạo đánh giá thành công";
            return result;
        }

        public async Task<ProductReviewResponseDTO> UpdateAsync(int id, UpdateProductReviewDTO dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Không tìm thấy đánh giá");

            // chỉ cho phép sửa điểm và nội dung
            entity.DiemDanhGia = dto.DiemDanhGia;
            entity.NoiDung = dto.NoiDung;
            entity.NgayCapNhat = DateTime.Now;

            await _repo.UpdateAsync(entity);
            await _repo.SaveChangesAsync();

            var result = _mapper.Map<ProductReviewResponseDTO>(entity);
            result.Message = "Cập nhật đánh giá thành công";
            return result;
        }

        public async Task<ProductReviewResponseDTO> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Không tìm thấy đánh giá");

            await _repo.DeleteAsync(entity);
            await _repo.SaveChangesAsync();

            var result = _mapper.Map<ProductReviewResponseDTO>(entity);
            result.Message = "Xóa đánh giá thành công";
            return result;
        }
    }
}

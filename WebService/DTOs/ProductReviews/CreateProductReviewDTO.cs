using System.ComponentModel.DataAnnotations;

namespace WebService.DTOs.ProductReviews
{
    public class CreateProductReviewDTO
    {
        [Required(ErrorMessage = "Mã sản phẩm là bắt buộc")]
        [StringLength(8, ErrorMessage = "Mã sản phẩm tối đa 8 ký tự")]
        public string MaSanPham { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mã người dùng là bắt buộc")]
        [StringLength(8, ErrorMessage = "Mã người dùng tối đa 8 ký tự")]
        public string MaNguoiDung { get; set; } = string.Empty;

        [Required(ErrorMessage = "Điểm đánh giá là bắt buộc")]
        [Range(1, 5, ErrorMessage = "Điểm đánh giá phải từ 1 đến 5")]
        public int DiemDanhGia { get; set; }

        [StringLength(100, ErrorMessage = "Nội dung tối đa 100 ký tự")]
        public string? NoiDung { get; set; }
    }
}

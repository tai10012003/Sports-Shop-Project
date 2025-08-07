using System.ComponentModel.DataAnnotations;

namespace WebService.DTOs.ProductReviews
{
    public class UpdateProductReviewDTO
    {
        [Required(ErrorMessage = "Điểm đánh giá là bắt buộc")]
        [Range(1, 5, ErrorMessage = "Điểm đánh giá phải từ 1 đến 5")]
        public int DiemDanhGia { get; set; }

        [StringLength(100, ErrorMessage = "Nội dung tối đa 100 ký tự")]
        public string? NoiDung { get; set; }
    }
}

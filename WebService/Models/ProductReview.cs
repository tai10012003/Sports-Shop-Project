using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("ProductReviews")]
    public class ProductReview
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ma_san_pham")]
        [StringLength(8)]
        public string MaSanPham { get; set; } = string.Empty;

        [Required]
        [Column("ma_nguoi_dung", TypeName = "varchar(8)")]
        public string MaNguoiDung { get; set; } = string.Empty;

        [Required]
        [Column("diem_danh_gia")]
        public int DiemDanhGia { get; set; }

        [Column("noi_dung", TypeName = "nvarchar(100)")]
        public string? NoiDung { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Column("ngay_cap_nhat")]
        public DateTime NgayCapNhat { get; set; } = DateTime.Now;
    }
}
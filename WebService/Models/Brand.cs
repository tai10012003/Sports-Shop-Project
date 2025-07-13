using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("Brands")]
    public class Brand
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("ma_thuong_hieu", TypeName = "varchar(8)")]
        public string MaThuongHieu { get; set; } = string.Empty;

        [Required]
        [Column("ten_thuong_hieu", TypeName = "nvarchar(50)")]
        public string TenThuongHieu { get; set; } = string.Empty;

        [Column("mo_ta", TypeName = "text")]
        public string? MoTa { get; set; }

        [Column("logo", TypeName = "varchar(255)")]
        public string? Logo { get; set; }

        [Column("website", TypeName = "varchar(100)")]
        public string? Website { get; set; }

        [Column("thu_tu")]
        public int ThuTu { get; set; } = 0;

        [Column("trang_thai")]
        public bool TrangThai { get; set; } = true;

        [Column("slug", TypeName = "varchar(255)")]
        public string Slug { get; set; } = string.Empty;

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Column("ngay_cap_nhat")]
        public DateTime NgayCapNhat { get; set; } = DateTime.Now;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("ma_danh_muc", TypeName = "varchar(8)")]
        public string MaDanhMuc { get; set; } = string.Empty;

        [Required]
        [Column("ten_danh_muc", TypeName = "nvarchar(50)")]
        public string TenDanhMuc { get; set; } = string.Empty;

        [Column("mo_ta", TypeName = "text")]
        public string? MoTa { get; set; }

        [Column("hinh_anh", TypeName = "varchar(255)")]
        public string? HinhAnh { get; set; }

        [Column("danh_muc_cha")]
        public int? DanhMucCha { get; set; }

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

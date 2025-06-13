using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("ProductImages")]
    public class ProductImage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("ma_san_pham")]
        [StringLength(8)]
        public string MaSanPham { get; set; } = string.Empty;

        [Required]
        [Column("duong_dan", TypeName = "varchar(255)")]
        public string DuongDan { get; set; } = string.Empty;

        [Column("thu_tu")]
        public int ThuTu { get; set; }

        [Column("anh_chinh")]
        public bool AnhChinh { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Column("ngay_cap_nhat")]
        public DateTime NgayCapNhat { get; set; } = DateTime.Now;

        [ForeignKey("MaSanPham")]
        public virtual Product? SanPham { get; set; }
    }
}

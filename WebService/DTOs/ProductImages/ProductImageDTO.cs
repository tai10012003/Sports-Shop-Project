namespace WebService.DTOs.ProductImages
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public string MaSanPham { get; set; } = string.Empty;
        public string DuongDan { get; set; } = string.Empty;
        public int ThuTu { get; set; }
        public bool AnhChinh { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }
}
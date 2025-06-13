namespace WebService.DTOs.Products
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public string MaSanPham { get; set; } = string.Empty;
        public string DuongDan { get; set; } = string.Empty;
        public int ThuTu { get; set; }
        public bool AnhChinh { get; set; }
    }
}
namespace WebService.DTOs.ProductImages
{
    public class CreateProductImageDTO
    {
        public string MaSanPham { get; set; } = string.Empty;
        public string DuongDan { get; set; } = string.Empty;
        public int ThuTu { get; set; }
        public bool AnhChinh { get; set; }
    }
}
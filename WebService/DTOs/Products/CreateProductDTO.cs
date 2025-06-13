namespace WebService.DTOs.Products
{
    public class CreateProductDTO
    {
        public string MaSanPham { get; set; } = string.Empty;
        public string TenSanPham { get; set; } = string.Empty;
        public string? MoTa { get; set; }
        public string? MoTaChiTiet { get; set; }
        public string? KichThuoc { get; set; }
        public string? MauSac { get; set; }
        public string? ChatLieu { get; set; }
        public string? XuatXu { get; set; }
        public string? BaoHanh { get; set; }
        public decimal Gia { get; set; }
        public decimal? GiaKhuyenMai { get; set; }
        public int SoLuong { get; set; }
        public string MaDanhMuc { get; set; } = string.Empty;
        public string MaThuongHieu { get; set; } = string.Empty;
        public bool TinhTrang { get; set; }
        public bool NoiBat { get; set; }
        public string Slug { get; set; } = string.Empty;
    }
}
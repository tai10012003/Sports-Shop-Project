namespace WebService.DTOs.Brands
{
    public class GetBrandDTO
    {
        public int Id { get; set; }
        public string MaThuongHieu { get; set; } = string.Empty;
        public string TenThuongHieu { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }
}
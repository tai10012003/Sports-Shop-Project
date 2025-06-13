namespace WebService.DTOs.Categories
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string MaDanhMuc { get; set; } = string.Empty;
        public string TenDanhMuc { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }
}
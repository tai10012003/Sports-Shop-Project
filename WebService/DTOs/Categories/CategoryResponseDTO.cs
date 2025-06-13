namespace WebService.DTOs.Categories
{
    public class CategoryResponseDTO : GetCategoryDTO
    {
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }
}
namespace WebService.DTOs.Brands
{
    public class BrandResponseDTO : GetBrandDTO
    {
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }
}
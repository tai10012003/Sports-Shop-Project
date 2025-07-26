using System.ComponentModel.DataAnnotations;

namespace WebService.DTOs.Users
{
    public class UpdateUserDTO
    {
        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [StringLength(40, ErrorMessage = "Họ tên không được vượt quá 40 ký tự")]
        public string HoTen { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string? SoDienThoai { get; set; }

        public string? DiaChi { get; set; }

        public string? MatKhauMoi { get; set; }

        public bool? TrangThai { get; set; }

        public string? Quyen { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WebService.DTOs.Users
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3-30 ký tự")]
        public string TenDangNhap { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [StringLength(40, ErrorMessage = "Họ tên không được vượt quá 40 ký tự")]
        public string HoTen { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6-100 ký tự")]
        public string MatKhau { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string? SoDienThoai { get; set; }

        public string? DiaChi { get; set; }

        public string Quyen { get; set; } = "user";

        public bool TrangThai { get; set; } = true;
    }
}
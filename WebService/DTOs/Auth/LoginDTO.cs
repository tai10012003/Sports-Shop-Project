namespace WebService.DTOs.Auth
{
    public class LoginDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Remember { get; set; } = false;
    }
}
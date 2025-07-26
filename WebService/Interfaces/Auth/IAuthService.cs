using WebService.DTOs.Auth;
using WebService.Models;

namespace WebService.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> LoginAsync(LoginDTO loginDto);
        Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDto);
        string GenerateJwtToken(User user);
    }
}
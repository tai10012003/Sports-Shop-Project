using WebService.DTOs.Users;

namespace WebService.Interfaces.Users
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDTO>> GetAllAsync();
        Task<GetUserDTO> GetByIdAsync(int id);
        Task<GetUserDTO> GetProfileAsync(int userId);
        Task<UserResponseDTO> UpdateProfileAsync(int userId, UpdateUserDTO dto);
        Task<UserResponseDTO> CreateAsync(CreateUserDTO dto);
        Task<UserResponseDTO> UpdateAsync(int id, UpdateUserDTO dto);
        Task<UserResponseDTO> DeleteAsync(int id);
    }
}

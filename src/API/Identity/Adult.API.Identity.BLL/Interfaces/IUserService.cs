using Adult.API.Identity.BLL.DTOs;

namespace Adult.API.Identity.BLL.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegistrationRequestDTO model);
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model);
        Task<UserInfoDTO> GetUserAsync();
    }
}

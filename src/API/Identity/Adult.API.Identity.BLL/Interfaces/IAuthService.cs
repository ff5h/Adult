using Adult.API.Identity.BLL.DTOs;

namespace Adult.API.Identity.BLL.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationRequestDTO model);
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model);
        GetUserResponseDTO GetUser();
    }
}

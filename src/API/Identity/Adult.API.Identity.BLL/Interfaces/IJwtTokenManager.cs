using Microsoft.AspNetCore.Http;

namespace Adult.API.Identity.BLL.Interfaces
{
    public interface IJwtTokenManager
    {
        string CreateToken(string email, string userId);
        string GetUserIdFromHeaderToken(HttpRequest request);
    }
}

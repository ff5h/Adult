using Adult.API.Identity.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace Adult.API.Identity.BLL.Interfaces
{
    public interface IJwtTokenManager
    {
        string CreateToken(User user);
        string GetUserIdFromHeaderToken(HttpRequest request);
    }
}

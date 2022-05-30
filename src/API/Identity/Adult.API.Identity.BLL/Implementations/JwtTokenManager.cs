using Adult.API.Identity.BLL.Extentions;
using Adult.API.Identity.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace Adult.API.Identity.BLL.Implementations
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IJwtGenerator _jwtGenerator;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtTokenManager(IJwtGenerator jwtGenerator, JwtSecurityTokenHandler tokenHandler)
        {
            _jwtGenerator = jwtGenerator;
            _tokenHandler = tokenHandler;
        }

        public string CreateToken(string email, string userId)
        {
            return _jwtGenerator.CreateToken(email, userId);
        }

        public string GetUserIdFromHeaderToken(HttpRequest request)
        {
            var token = request.GetAuthorizationToken();

            var jwtToken = _tokenHandler.ReadJwtToken(token);
            var claim = jwtToken.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            return claim.Value;
        }
    }
}

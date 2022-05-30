using Adult.API.Identity.BLL.Extentions;
using Adult.API.Identity.BLL.Interfaces;
using Adult.API.Identity.DAL.Entities;
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

        public string CreateToken(User user)
        {
            return _jwtGenerator.CreateToken(user);
        }

        public string GetUserIdFromHeaderToken(HttpRequest request)
        {
            var token = request.GetAuthorizationToken();

            var jwtToken = _tokenHandler.ReadJwtToken(token);
            var claim = jwtToken.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            if (claim == null)
            {
                throw new Exception("JwtRegisteredClaimNames.Sub more when one");
            }
            return claim.Value;
        }
    }
}

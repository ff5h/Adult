using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace Adult.API.Identity.BLL.Extentions
{
    public static class HttpRequestExtentions
    {
        public static string GetAuthorizationToken(this HttpRequest request) =>
            request.GetAuthorizationHeaderValue()?.Split(" ").Last();

        public static string GetAuthorizationHeaderValue(this HttpRequest request) =>
            request.Headers.TryGetValue("Authorization", out var authorizationHeader)
                ? authorizationHeader.ToString()
                : null;

        public static string GetUserIdFromAuthorizationToken(this HttpRequest request, JwtSecurityTokenHandler tokenHandler)
        {
            var token = request.GetAuthorizationToken();

            var jwtToken = tokenHandler.ReadJwtToken(token);
            var claim = jwtToken.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            return claim?.Value;
        }
    }
}
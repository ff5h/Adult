﻿using Adult.API.Identity.BLL.Configurations;
using Adult.API.Identity.BLL.Interfaces;
using Adult.API.Identity.DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Adult.API.Identity.BLL.Implementations
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly SigningCredentials _credentials;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtGenerator(JwtConfiguration jwtConfiguration, JwtSecurityTokenHandler tokenHandler)
        {
            _jwtConfiguration = jwtConfiguration;
            _tokenHandler = tokenHandler;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key));
            _credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
        public string CreateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtConfiguration.LifeTime),
                SigningCredentials = _credentials
            };
            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
        }
    }
}

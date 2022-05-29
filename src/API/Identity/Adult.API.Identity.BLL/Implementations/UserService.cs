using Adult.API.Identity.BLL.DTO;
using Adult.API.Identity.BLL.DTOs;
using Adult.API.Identity.BLL.Interfaces;
using Adult.API.Identity.DAL.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Adult.API.Identity.BLL.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUserAccesor _userAccesor;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, IMapper mapper, IUserAccesor userAccesor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
            _userAccesor = userAccesor;
        }

        public async Task RegisterAsync(RegistrationRequestDTO model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                throw new Exception("User already exists!");

            UserDTO userDTO = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var user = _mapper.Map<User>(userDTO);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new Exception(String.Join(",", result.Errors.Select(x => x.Description).ToArray().Select(x => x.ToString()).ToArray()));
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                throw new Exception("Unauthorized");
            }
            var authResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (authResult != SignInResult.Success)
            {
                throw new Exception("HZ");
            }
            var token = CreateToken(user);
            return new LoginResponseDTO()
            {
                Token = token,
            };
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.NameId, user.UserName) };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<UserInfoDTO> GetUserAsync()
        {
            var user = await _userAccesor.GetUserAsync();
            return new UserInfoDTO()
            { 
                Id = user.Id,
            };
        }
    }
}

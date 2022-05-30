using Adult.API.Identity.BLL.DTOs;
using Adult.API.Identity.BLL.DTOs;
using Adult.API.Identity.BLL.Interfaces;
using Adult.API.Identity.DAL.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Adult.API.Identity.BLL.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly IHttpContextAccessor _accessor;

        public AuthService(UserManager<User> userManager,
                           SignInManager<User> signInManager,
                           IMapper mapper,
                           IHttpContextAccessor accessor,
                           IJwtTokenManager jwtTokenManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _accessor = accessor;
            _jwtTokenManager = jwtTokenManager;
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
                throw new Exception("Пароль не верный");
            }
            var token = _jwtTokenManager.CreateToken(user);
            return new LoginResponseDTO()
            {
                Token = token
            };
        }

        public UserInfoDTO GetUser()
        {
            var httpRequest = _accessor.HttpContext.Request;
            var userId = _jwtTokenManager.GetUserIdFromHeaderToken(httpRequest);
            return new UserInfoDTO()
            {
                Id = userId,
            };
        }
    }
}

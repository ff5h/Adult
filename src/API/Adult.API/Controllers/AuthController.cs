using Adult.API.Identity.BLL.DTOs;
using Adult.API.Identity.BLL.Interfaces;
using Adult.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adult.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService userService, IMapper mapper)
        {
            _authService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var requestDTO = _mapper.Map<LoginRequestDTO>(request);
            var result = await _authService.LoginAsync(requestDTO);
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            var requestDTO = _mapper.Map<RegistrationRequestDTO>(request);
            await _authService.RegisterAsync(requestDTO);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("getuser")]
        public IActionResult GetUser()
        {
            var result = _authService.GetUser();
            return Ok(result);
        }
    }
}

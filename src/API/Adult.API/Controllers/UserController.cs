using Adult.API.Identity.BLL.DTOs;
using Adult.API.Identity.BLL.Interfaces;
using Adult.API.Identity.DAL.Entities;
using Adult.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Adult.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var requestDTO = _mapper.Map<LoginRequestDTO>(request);
            var result = await _userService.LoginAsync(requestDTO);
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            var requestDTO = _mapper.Map<RegistrationRequestDTO>(request);
            await _userService.RegisterAsync(requestDTO);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("getuser")]
        public async Task<IActionResult> GetUser()
        {
            var result = await _userService.GetUserAsync();
            return Ok(result);
        }
    }
}

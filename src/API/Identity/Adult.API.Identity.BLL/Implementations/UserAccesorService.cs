using Adult.API.Identity.BLL.Interfaces;
using Adult.API.Identity.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Adult.API.Identity.BLL.Implementations
{
    public class UserAccesorService : IUserAccesor
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<User> _userManager;

        public UserAccesorService(IHttpContextAccessor accessor, UserManager<User> userManager)
        {
            _accessor = accessor;
            _userManager = userManager;
        }

        public async Task<User> GetUserAsync()
        {
            var user = _accessor.HttpContext.User;
            return await _userManager.GetUserAsync(user);
        }

        public string GetUserId()
        {
            var claimsPrincipal = _accessor.HttpContext.User;
            var id = _userManager.GetUserId(claimsPrincipal);
            return id;
        }
    }
}

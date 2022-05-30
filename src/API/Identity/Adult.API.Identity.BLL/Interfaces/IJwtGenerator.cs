using Adult.API.Identity.DAL.Entities;

namespace Adult.API.Identity.BLL.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(User user);
    }
}

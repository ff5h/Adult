namespace Adult.API.Identity.BLL.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(string email, string userId);
    }
}
